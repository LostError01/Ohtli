using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Animator Camara")]
    [SerializeField] private Animator animCamara;

    [Header("Luz Animator")]
    [SerializeField] private Animator luzAnim;

    [Header("Pantalla de Luz Animator")]
    [SerializeField] private Animator PantallaLuzAnim;

    [Header("Papel Animator")]
    [SerializeField] private Animator papelAnim;

    [Header("Boton Luz Provisional")]
    [SerializeField] private Button botonLuzProvisional;

    public void PantallaRecortes()
    {
        if (animCamara.GetInteger("Pantalla") == 0)
        {
            animCamara.SetInteger("Pantalla", 1);
            botonLuzProvisional.enabled = false;
        }
    }

    public void PantallaPrincipal()
    {
        if (animCamara.GetInteger("Pantalla") == 1)
        {
            animCamara.SetInteger("Pantalla", 0);
            botonLuzProvisional.enabled = true;
        }
    }

    public void EncenderPantalla()
    {
        if(luzAnim.GetBool("Encender") == false)
        {
            luzAnim.SetBool("Encender", true);
            PantallaLuzAnim.SetBool("Encendida", true);
        }
        else
        {
            luzAnim.SetBool("Encender", false);
            PantallaLuzAnim.SetBool("Encendida", false);
        }
    }

    public void TraerPapel()
    {
        if (papelAnim.GetInteger("Accion") == 0)
        {
            papelAnim.SetInteger("Accion", 1);
        }
    }

    private IEnumerator PapelReiniciar()
    {
        yield return new WaitForSeconds(1f);
        papelAnim.SetInteger("Accion", 0);
    }
}
