using UnityEngine;
using TMPro;
using System.Collections;
using Ink.Parsed;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // 4. Parches para iniciar el evento
    private int parche = 0;

    // 5. Variables de tiempo
    private float tiempoLimite = 5f;
    private bool tiempoAcabado = false;

    [Header("Caja de Texto")]
    [SerializeField] private TextMeshProUGUI cajaTexto;

    [Header("Pines de letra apretada correcta")]
    [SerializeField] private List <GameObject> pinesLetras = new List <GameObject>();

    [Header("Animator Ventana QuickTimeEvent")]
    [SerializeField] private Animator ventanaQTEAnim;

    [Header("Animator Hoja para Recortar")]
    [SerializeField] private Animator hojaRecortarAnim;

    [Header("Parches de la hoja de repuesto")]
    [SerializeField] private List<GameObject> parches = new List<GameObject>();

    [Header("Animator de Parches de Repuesto")]
    [SerializeField] private List<Animator> parchesAnim = new List<Animator>();

    [Header("Parches finales para draggear")]
    [SerializeField] private List<GameObject> parchesFinales = new List<GameObject>();


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
    }

    private void Update()
    {
        if (eventoIniciado)
        {
            VerificarTeclas();
            ventanaQTEAnim.SetBool("Ventana",true);

            tiempoLimite -= Time.deltaTime;
            //Solo ejecutar por 5 segundos
            if (tiempoLimite <= 0f)
            {
                tiempoAcabado = true;
                cajaTexto.text = "Se ha acabado el tiempo, intentalo de nuevo";
                //tiempoLimite = 5f;
                StartCoroutine(Perdiste(2f));
            }
        }
        if(!eventoIniciado)
        {
            ventanaQTEAnim.SetBool("Ventana",false);
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

        if(parche == 1)
        {
            parches[0].SetActive(true);
            parchesAnim[0].SetBool("Recorte",true);
            parchesFinales[0].SetActive(true);
        }
        else if(parche == 2)
        {
            parches[1].SetActive(true);
            parchesAnim[1].SetBool("Recorte",true);
            parchesFinales[1].SetActive(true);
        }
        else if(parche == 3)
        {
            parches[2].SetActive(true);
            parchesAnim[2].SetBool("Recorte",true);
            parchesFinales[2].SetActive(true);
        }
        else if(parche == 4)
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
    }

    //Evento para botones
    public void EventoParche1()
    {
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0)
        {
            GenerarSecuenciaAleatoria();
            parche = 1;
        }
        else
        {
            return;
        }

        eventoIniciado = true;
    }

    public void EventoParche2()
    {
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0)
        {
            GenerarSecuenciaAleatoria();
            parche = 2;
        }
        else
        {
            return;
        }

        eventoIniciado = true;
    }

    public void EventoParche3()
    {
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0)
        {
            GenerarSecuenciaAleatoria();
            parche = 3;
        }
        else
        {
            return;
        }
        eventoIniciado = true;
    }

    public void EventoParche4()
    {
        tiempoLimite = 5f;
        if (mouseHabilitado && hojaRecortarAnim.GetInteger("Accion") == 1 && parche == 0)
        {
            GenerarSecuenciaAleatoria();
            parche = 4;
        }
        else
        {
            return;
        }
        eventoIniciado = true;
    }
}