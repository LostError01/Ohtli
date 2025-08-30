using UnityEngine;
using TMPro;
using System.Collections;
using Ink.Parsed;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
public class QuickTimeEvent : MonoBehaviour
{
    // 1. Letras a elegir y la secuencia que las guardara
    private char[] letrasBase = { 'A', 'S', 'D', 'F' };
    private char[] secuencia = new char[4]; // Secuencia aleatoria CON REPETICIONES

    // 2. Numero de teclas presionadas
    private int pasoActual = 0;

    // 3. Banderas para controlar el evento
    private bool eventoIniciado = false;
    private bool mouseHabilitado = true;
    private bool hasGanado = false;

    // 4. Parches para iniciar el evento
    private int parche = 0;

    // 5. Variables de tiempo
    private float tiempoLimite = 5f;
    private bool tiempoAcabado = false;

    [Header("Caja de Texto")]
    [SerializeField] private TextMeshProUGUI cajaTexto;

    [Header("Aviso de traer papel")]
    [SerializeField] private TextMeshProUGUI avisoTraerPapel;
    [SerializeField] private Animator avisoTraerPapelAnim;

    [Header("Pines de letra apretada correcta")]
    [SerializeField] private List <GameObject> pinesLetras = new List <GameObject>();

    [Header("Animator Ventana QuickTimeEvent")]
    [SerializeField] private Animator ventanaQTEAnim;

    [Header("Animator Hoja para Recortar")]
    [SerializeField] private Animator hojaRecortarAnim;

    [Header("Aniamtor Reloj de ventana")]
    [SerializeField] private Animator relojAnim;

    [Header("Slider de Recortes")]
    [SerializeField] private Slider sliderRecortes;

    [Header("Parches de la hoja de repuesto")]
    [SerializeField] private List<GameObject> parches = new List<GameObject>();

    [Header("Animator de Parches de Repuesto")]
    [SerializeField] private List<Animator> parchesAnim = new List<Animator>();

    [Header("Parches finales para draggear")]
    [SerializeField] private List<GameObject> parchesFinales = new List<GameObject>();

    [Header("Botones de recortes")]
    [SerializeField] private List<GameObject> botonesRecortes = new List<GameObject>();

    [Header("Elementos de Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioVentana;


    private void Start()
    {
        mouseHabilitado = true;

        foreach (GameObject pin in pinesLetras)
        {
            pin.SetActive(false);
        }

        foreach (GameObject parche in parches)
        {
            parche.SetActive(false);
        }

        sliderRecortes.value = 0;
        sliderRecortes.maxValue = tiempoLimite;
    }

    private void Update()
    {
        if (eventoIniciado)
        {
            VerificarTeclas();
            ventanaQTEAnim.SetBool("Ventana",true);
            relojAnim.SetTrigger("Tiempo");

            tiempoLimite -= Time.deltaTime;

            sliderRecortes.value = tiempoLimite;

            //Solo ejecutar por 5 segundos
            if (tiempoLimite <= 0f && !hasGanado)
            {
                tiempoAcabado = true;
                cajaTexto.text = "Se ha acabado el tiempo, intentalo de nuevo";
                StartCoroutine(Perdiste(2f));
            }

            //Detener el flujo del tiempo si se ha ganado o perdido
            if (hasGanado || !mouseHabilitado)
            {
                tiempoLimite += Time.deltaTime;
                //Valor en el que se quedo el cronometro
                sliderRecortes.value = tiempoLimite;
            }
        }
        if(!eventoIniciado)
        {
            ventanaQTEAnim.SetBool("Ventana",false);
        }

        //Si el parches[0] esta activo\
        if (parches[0].activeSelf)
        {
            botonesRecortes[0].SetActive(false);
        }
        else if (!parches[0].activeSelf)
        {
            botonesRecortes[0].SetActive(true);
        }


        if (parches[1].activeSelf)
        {
            botonesRecortes[1].SetActive(false);
        }
        else if (!parches[1].activeSelf)
        {
            botonesRecortes[1].SetActive(true);
        }

        if (parches[2].activeSelf)
        {
            botonesRecortes[2].SetActive(false);
        }
        else if (!parches[2].activeSelf)
        {
            botonesRecortes[2].SetActive(true);
        }

        if (parches[3].activeSelf)
        {
            botonesRecortes[3].SetActive(false);
        }
        else if (!parches[3].activeSelf)
        {
            botonesRecortes[3].SetActive(true);
        }
    }

    // Se genera una secuencia aleatoria de teclas
    private void GenerarSecuenciaAleatoria()
    {
        // Generamos una secuencia aleatoria de 4 letras
        for (int i = 0; i < 4; i++)
        {
            secuencia[i] = letrasBase[Random.Range(0, letrasBase.Length)];
        }

        cajaTexto.text = "¡Presiona en orden: <br>";
        for (int i = 0; i < 4; i++)
            cajaTexto.text += secuencia[i] + " ";
        cajaTexto.text += "!";

        //Se reinicia el paso actual cada vez que se genera una nueva secuencia
        pasoActual = 0;
    }

    // Funcion que verifica si se presionan las teclas correctas
    private void VerificarTeclas()
    {
        // Si tocas letra correcta, avanza al siguiente paso
        if (Input.GetKeyDown(KeyCode.A)) CheckearTecla('A');
        if (Input.GetKeyDown(KeyCode.S)) CheckearTecla('S');
        if (Input.GetKeyDown(KeyCode.D)) CheckearTecla('D');
        if (Input.GetKeyDown(KeyCode.F)) CheckearTecla('F');
    }

    // Checa si la tecla presionada es la correcta
    private void CheckearTecla(char teclaPresionada)
    {
        audioSource.PlayOneShot(audioVentana);
        // Si la tecla presionada es igual al elemento actual de la secuencia [pasoActual] = indice
        if (teclaPresionada == secuencia[pasoActual] && !tiempoAcabado)
        {
            //Activar pin de letra correcta
            pinesLetras[pasoActual].SetActive(true);

            pasoActual++;

            //Si llegas a 4
            if (pasoActual == 4)
            {
                cajaTexto.text = "Recortando...";
                StartCoroutine(Ganaste(2f));
            }
        }
        else // ¡Error! Tecla incorrecta
        {
                cajaTexto.text = "¡Fallaste!";
                StartCoroutine(Perdiste(2f));
        }
    }

    private IEnumerator Perdiste(float delay)
    {
        mouseHabilitado = false;

        //Desactivar pines de letras correctas
        foreach (GameObject pin in pinesLetras)
        {
            pin.SetActive(false);
        }

        yield return new WaitForSeconds(delay);

        eventoIniciado = false; 
        mouseHabilitado = true; 
        parche = 0;
        tiempoAcabado = false;
    }

    private IEnumerator Ganaste(float delay)
    {
        mouseHabilitado = false;
        hasGanado = true;

        if (parche == 1)
        {
            parches[0].SetActive(true);
            parchesAnim[0].SetBool("Recorte",true);
            parchesFinales[0].SetActive(true);
        }
        if(parche == 2)
        {
            parches[1].SetActive(true);
            parchesAnim[1].SetBool("Recorte",true);
            parchesFinales[1].SetActive(true);
        }
        if(parche == 3)
        {
            parches[2].SetActive(true);
            parchesAnim[2].SetBool("Recorte",true);
            parchesFinales[2].SetActive(true);
        }
        if(parche == 4)
        {
            parches[3].SetActive(true);
            parchesAnim[3].SetBool("Recorte",true);
            parchesFinales[3].SetActive(true);
        }

        yield return new WaitForSeconds(delay);

        foreach (GameObject pin in pinesLetras)
        {
            pin.SetActive(false);
        }

        eventoIniciado = false; 
        mouseHabilitado = true; 
        parche = 0;
        tiempoAcabado = false;
        hasGanado = false;
    }

    private IEnumerator AvisoTraerPapel(float delay)
    {
        avisoTraerPapelAnim.SetBool("Start", true);
        yield return new WaitForSeconds(delay);
        avisoTraerPapelAnim.SetBool("Start", false);
    }

    //Evento para botones
    public void EventoParche1()
    {
        audioSource.PlayOneShot(audioVentana);
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0 && ButtonFunctions.bisturiSeleccionado)
        {
            botonesRecortes[0].SetActive(false);
            botonesRecortes[1].SetActive(false);
            botonesRecortes[2].SetActive(false);
            botonesRecortes[3].SetActive(false);
            GenerarSecuenciaAleatoria();
            parche = 1;
        }
        else
        {
            if (!ButtonFunctions.bisturiSeleccionado)
            {
                avisoTraerPapel.text = "¡Debes seleccionar el bisturí primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
            else
            {
                avisoTraerPapel.text = "¡Debes traer la hoja primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
        }

        eventoIniciado = true;
    }

    public void EventoParche2()
    {
        audioSource.PlayOneShot(audioVentana);
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0 && ButtonFunctions.bisturiSeleccionado)
        {
            botonesRecortes[0].SetActive(false);
            botonesRecortes[1].SetActive(false);
            botonesRecortes[2].SetActive(false);
            botonesRecortes[3].SetActive(false);
            GenerarSecuenciaAleatoria();
            parche = 2;
        }
        else
        {
            if (!ButtonFunctions.bisturiSeleccionado)
            {
                avisoTraerPapel.text = "¡Debes seleccionar el bisturí primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
            else
            {
                avisoTraerPapel.text = "¡Debes traer la hoja primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
        }

        eventoIniciado = true;
    }

    public void EventoParche3()
    {
        audioSource.PlayOneShot(audioVentana);
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0 && ButtonFunctions.bisturiSeleccionado)
        {
            botonesRecortes[0].SetActive(false);
            botonesRecortes[1].SetActive(false);
            botonesRecortes[2].SetActive(false);
            botonesRecortes[3].SetActive(false);
            GenerarSecuenciaAleatoria();
            parche = 3;
        }
        else
        {
            if (!ButtonFunctions.bisturiSeleccionado)
            {
                avisoTraerPapel.text = "¡Debes seleccionar el bisturí primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
            else
            {
                avisoTraerPapel.text = "¡Debes traer la hoja primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
        }
        eventoIniciado = true;
    }

    public void EventoParche4()
    {
        audioSource.PlayOneShot(audioVentana);
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0 && ButtonFunctions.bisturiSeleccionado)
        {
            botonesRecortes[0].SetActive(false);
            botonesRecortes[1].SetActive(false);
            botonesRecortes[2].SetActive(false);
            botonesRecortes[3].SetActive(false);
            GenerarSecuenciaAleatoria();
            parche = 4;

        }
        else
        {
            if (!ButtonFunctions.bisturiSeleccionado)
            {
                avisoTraerPapel.text = "¡Debes seleccionar el bisturí primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
            else
            {
                avisoTraerPapel.text = "¡Debes traer la hoja primero!";
                StartCoroutine(AvisoTraerPapel(3f));
                return;
            }
        }
        eventoIniciado = true;
    }
}