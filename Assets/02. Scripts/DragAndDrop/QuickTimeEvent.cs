using UnityEngine;
using TMPro;
using System.Collections;
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

    [Header("Caja de Texto")]
    [SerializeField] private TextMeshProUGUI cajaTexto;

    private void Update()
    {
        if (eventoIniciado)
            VerificarTeclas();
        if(!eventoIniciado)
            cajaTexto.text = "¡Presiona el recorte deseado para iniciar el evento!";
    }

    private void OnMouseDown()
    {
        if(mouseHabilitado)
        GenerarSecuenciaAleatoria();
        eventoIniciado = true;
    }

    // Se genera una secuencia aleatoria de teclas
    private void GenerarSecuenciaAleatoria()
    {
        // Generamos una secuencia aleatoria de 4 letras
        for (int i = 0; i < 4; i++)
        {
            secuencia[i] = letrasBase[Random.Range(0, letrasBase.Length)];
        }

        cajaTexto.text = "¡Presiona en orden: ";
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
        if (teclaPresionada == secuencia[pasoActual])
        {
            pasoActual++;

            //Si llegas a 4
            if (pasoActual == 4)
            {
                cajaTexto.text = "¡Éxito! Evento completado";
                StartCoroutine(Ganaste(2f));
            }
        }
        else // ¡Error! Tecla incorrecta
        {
            cajaTexto.text = "¡Fallaste! Reiniciando...";
            StartCoroutine(Perdiste(2f));
        }
    }

    private IEnumerator Perdiste(float delay)
    {
        mouseHabilitado = false; 
        yield return new WaitForSeconds(delay);
        eventoIniciado = false; 
        mouseHabilitado = true; 
    }

    private IEnumerator Ganaste(float delay)
    {
        mouseHabilitado = false; 
        yield return new WaitForSeconds(delay);
        eventoIniciado = false; 
        mouseHabilitado = true; 
    }
}