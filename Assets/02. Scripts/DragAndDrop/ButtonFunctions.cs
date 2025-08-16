using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Animator Camara")]
    [SerializeField] private Animator animCamara;

    [Header("Luz Animator")]
    [SerializeField] private Animator luzAnim;
    public void PantallaRecortes()
    {
        if (animCamara.GetInteger("Pantalla") == 0)
        {
            animCamara.SetInteger("Pantalla", 1);
        }
    }

    public void PantallaPrincipal()
    {
        if (animCamara.GetInteger("Pantalla") == 1)
        {
            animCamara.SetInteger("Pantalla", 0);
        }
    }

    public void EncenderPantalla()
    {
        if(luzAnim.GetBool("Encender") == false)
        {
            luzAnim.SetBool("Encender", true);
        }
        else
        {
            luzAnim.SetBool("Encender", false);
        }
    }
}
