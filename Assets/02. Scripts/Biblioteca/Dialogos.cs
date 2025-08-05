using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{

    [Header("Animator del Dialogo")]
    public Animator animDialogo;

    [Header("Texto")]
    public Text textoDialogo;

    private string[] dialogo = new string[]
    {
        "Lorem ipsum o como sea",
        "Dialogo 2 ehhhh ahhh necesito hacer el dialogo largo a ver si se adapta el texto al tamaniooo del cuadro de texto ajajajajajaaj",
        "Hola dialogo 3 inserte texto aquí",
        "Dialogo 4, Sample Text, haga click dos veces para editar aaaaaaa"
    };

    private bool dialogoActivo = false;
    void Start()
    {
        
    }

    void Update()
    {
        //Mostar animacion del dialogo
        if (dialogoActivo)
        {
            animDialogo.SetBool("MostrarDialogo", true);
        }
        else
        {
            animDialogo.SetBool("MostrarDialogo", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC01"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                dialogoActivo = true;
                textoDialogo.text = dialogo[0]; 
            }
        }

        if (collision.CompareTag("NPC02"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                dialogoActivo = true;
                textoDialogo.text = dialogo[1];
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC01") || collision.CompareTag("NPC02"))
        {
            dialogoActivo = false;
        }
    }
}
