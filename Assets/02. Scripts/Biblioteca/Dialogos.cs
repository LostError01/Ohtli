using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class Dialogos : MonoBehaviour
{

    [Header("Animator del Dialogo")]
    public Animator animDialogo;

    [Header("Texto")]
    public Text textoDialogo;

    [Header("Velocidad de Texto")]
    [SerializeField] private float velocidadTexto = 0.1f;

    private string[] dialogo = new string[] // (Poner un espacio antes del dialogo)
    {
        "Lorem ipsum o como sea",
        "Dialogo 2 ehhhh ahhh necesito hacer el dialogo largo a ver si se adapta el texto al tamaniooo del cuadro de texto ajajajajajaaj",
        "Hola dialogo 3 inserte texto aquí",
        "Dialogo 4, Sample Text, haga click dos veces para editar aaaaaaa"
    };

    // INDICE DEL DIALOGO ACTUAL
    private int dialogoIndex;

    // ESTADO DEL DIALOGO
    private bool dialogoActivo = false;

    // VARIABLE PARA SABER SI YA SE HA ESCRITO EL TEXTO
    private bool haEscrito = false ;

    // VARIABLE PARA EVITAR QUE SE ESCRIBA EL TEXTO VARIAS VECES
    private bool botonApretado = false;

    void Start()
    {
        
    }

    void Update()
    {
        //Mostar animacion del dialogo
        if (dialogoActivo)
        {
            animDialogo.SetBool("MostrarDialogo", true);
            if (!haEscrito)
            {
                StartCoroutine(EfectoTexto());
                haEscrito = true;
            }
        }
        else
        {
            animDialogo.SetBool("MostrarDialogo", false);
            haEscrito = false;
        }
    }

    IEnumerator EfectoTexto()
    {
        foreach (char letra in dialogo[dialogoIndex].ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadTexto);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC01"))
        {
            if (Input.GetKey(KeyCode.E) && !botonApretado)
            {
                textoDialogo.text = string.Empty;
                dialogoActivo = true;
                dialogoIndex = 0;

                botonApretado = true;
            }
        }

        if (collision.CompareTag("NPC02"))
        {
            if (Input.GetKey(KeyCode.E) && !botonApretado)
            {
                textoDialogo.text = string.Empty;
                dialogoActivo = true;
                dialogoIndex = 1;

                botonApretado = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC01") || collision.CompareTag("NPC02"))
        {
            dialogoActivo = false;
            botonApretado = false;
        }
    }
}
