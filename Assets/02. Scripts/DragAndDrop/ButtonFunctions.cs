using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Animator Camara")]
    [SerializeField] private Animator animCamara;

    [Header("Luz Animator")]
    [SerializeField] private Animator luzAnim;

    [Header("Boton Luz Provisional")]
    [SerializeField] private Button botonLuzProvisional;
    [SerializeField] private TextMeshProUGUI textoBotonLuzProvisional;

    public void PantallaRecortes()
    {
        if (animCamara.GetInteger("Pantalla") == 0)
        {
            animCamara.SetInteger("Pantalla", 1);
            botonLuzProvisional.enabled = false;
            textoBotonLuzProvisional.enabled = false;
        }
    }

    public void PantallaPrincipal()
    {
        if (animCamara.GetInteger("Pantalla") == 1)
        {
            animCamara.SetInteger("Pantalla", 0);
            botonLuzProvisional.enabled = true;
            textoBotonLuzProvisional.enabled = true;
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
