using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Ink.Parsed;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Animator Camara")]
    [SerializeField] private Animator animCamara;

    [Header("Animator Hoja final")]
    [SerializeField] private Animator hojaFinalAnim;

    [Header("Luz Animator")]
    [SerializeField] private Animator luzAnim;

    [Header("Pantalla de Luz Animator")]
    [SerializeField] private Animator PantallaLuzAnim;

    [Header("Papel Animator")]
    [SerializeField] private Animator papelAnim;

    [Header("Boton Luz Provisional")]
    [SerializeField] private Button botonLuzProvisional;

    [Header("Animator Boton de Peso")]
    [SerializeField] private Animator botonPesoAnim;

    [Header("Canvas de pantalla Principal")]
    [SerializeField] private Canvas pantalla01Canvas;

    [Header("Canvas de pantalla Recortes")]
    [SerializeField] private Canvas pantalla02Canvas;

    [Header("Canvas de Pantalla general")]
    [SerializeField] private Canvas pantallaGeneralCanvas;

    [Header("Canvas Pantalla Final")]
    [SerializeField] private Canvas pantalla03Canvas;

    [Header("Iconos de visualizacion")]
    [SerializeField] private SpriteRenderer iconoBisturi;
    [SerializeField] private SpriteRenderer iconoBrocha;
    [SerializeField] private SpriteRenderer iconoPincel;

    [Header("Parches")]
    [SerializeField] private List <GameObject> parches = new List<GameObject>();

    [Header("Boton Final")]
    [SerializeField] private Button botonFinal;

    [Header("Boton Peso")]
    [SerializeField] private Button botonPeso;

    [Header("Glifo")]
    [SerializeField] private GameObject glifo;
    [SerializeField] private Button glifoBtn;

    [Header("Animator cronometro")]
    [SerializeField] private Animator cronometroAnim;

    [Header("Elementos de Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip botonAudio;
    [SerializeField] private AudioClip herramientaAudio;
    [SerializeField] private AudioClip relojAudio;

    public static bool bisturiSeleccionado = false;
    public static bool brochaSeleccionada = false;
    public static bool pincelSeleccionado = false;

    private void Start()
    {
        pantalla01Canvas.enabled = true;
        pantalla02Canvas.enabled = false;

        iconoBisturi.enabled = false;
        iconoBrocha.enabled = false;
        iconoPincel.enabled = false;

        //Desactivar Sprites de recortes
        GameObject.Find("Boton Parche1 (Contiene el script del evento)").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Boton Parche2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Boton Parche3").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Boton Parche4").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void PantallaRecortes()
    {
        if (animCamara.GetInteger("Pantalla") == 0)
        {
            animCamara.SetInteger("Pantalla", 1);
            StartCoroutine(MostrarPantalla1());
            botonLuzProvisional.enabled = false;

            audioSource.PlayOneShot(botonAudio);
        }
    }

    public void PantallaPrincipal()
    {
        if (animCamara.GetInteger("Pantalla") == 1)
        {
            animCamara.SetInteger("Pantalla", 0);
            StartCoroutine(MostrarPantalla0());
            botonLuzProvisional.enabled = true;

            audioSource.PlayOneShot(botonAudio);
        }
    }

    public void PantallaFinal()
    {
        if (animCamara.GetInteger("Pantalla") == 0)
        {
            animCamara.SetInteger("Pantalla", 2);
            hojaFinalAnim.SetTrigger("MoverHoja");
            StartCoroutine(MostrarPantalla3());

            audioSource.PlayOneShot(botonAudio);
        }
    }

    public void EncenderPantalla()
    {
        if(luzAnim.GetBool("Encender") == false)
        {
            luzAnim.SetBool("Encender", true);
            PantallaLuzAnim.SetBool("Encendida", true);

            audioSource.PlayOneShot(botonAudio);
        }
        else
        {
            luzAnim.SetBool("Encender", false);
            PantallaLuzAnim.SetBool("Encendida", false);

            audioSource.PlayOneShot(botonAudio);
        }
    }

    public void Bisturi()
    {
        audioSource.PlayOneShot(herramientaAudio);

        iconoBisturi.enabled = true;
        iconoBrocha.enabled = false;
        iconoPincel.enabled = false;

        bisturiSeleccionado = true;
        brochaSeleccionada = false;
        pincelSeleccionado = false;
    }

    public void Brocha()
    {
        audioSource.PlayOneShot(herramientaAudio);

        iconoBisturi.enabled = false;
        iconoBrocha.enabled = true;
        iconoPincel.enabled = false;

        brochaSeleccionada = true;  
        bisturiSeleccionado = false;
        pincelSeleccionado = false;
    }

    public void Pincel()
    {
        audioSource.PlayOneShot(herramientaAudio);

        iconoBisturi.enabled = false;
        iconoBrocha.enabled = false;
        iconoPincel.enabled = true;

        pincelSeleccionado = true;
        bisturiSeleccionado = false;
        brochaSeleccionada = false;
    }

    public void NoHerramienta()
    {
        audioSource.PlayOneShot(botonAudio);

        iconoBisturi.enabled = false;
        iconoBrocha.enabled = false;
        iconoPincel.enabled = false;
        pincelSeleccionado = false;
        bisturiSeleccionado = false;
        brochaSeleccionada = false;
    }

    public void TraerPapel()
    {
        if (papelAnim.GetInteger("Accion") == 0)
        {
            papelAnim.SetInteger("Accion", 1);

            audioSource.PlayOneShot(botonAudio);
        }
    }

    public void AplicarPeso()
    {
        botonPesoAnim.SetBool("Mostrar", true);
        cronometroAnim.SetBool("Spawn", true);
        audioSource.PlayOneShot(botonAudio);
        StartCoroutine(QuitarPeso());
    }

    public void ComenzarAventura()
    {
        SceneManager.LoadScene("E4");

        audioSource.PlayOneShot(herramientaAudio);
    }

    private IEnumerator MostrarPantalla0()
    {
        pantalla02Canvas.enabled = false;
        yield return new WaitForSeconds(0.4f);
        pantalla01Canvas.enabled = true;
    }

    private IEnumerator MostrarPantalla1()
    {
        pantalla01Canvas.enabled = false;
        yield return new WaitForSeconds(0.4f);
        pantalla02Canvas.enabled = true;

        //Activar Sprites de recortes
        GameObject.Find("Boton Parche1 (Contiene el script del evento)").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Boton Parche2").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Boton Parche3").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Boton Parche4").GetComponent<SpriteRenderer>().enabled = true;
    }

    private IEnumerator MostrarPantalla3()
    {
        pantalla01Canvas.enabled = false;
        pantalla02Canvas.enabled = false;
        pantallaGeneralCanvas.enabled = false;
        yield return new WaitForSeconds(0.4f);
        pantalla03Canvas.enabled = true;
    }

    private IEnumerator QuitarPeso()
    {
        audioSource.PlayOneShot(relojAudio);
        botonPeso.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        foreach (GameObject parche in parches)
        {
            parche.SetActive(false);
        }
        audioSource.Stop();
        botonPesoAnim.SetBool("Mostrar", false);
        cronometroAnim.SetBool("Spawn", false);
        yield return new WaitForSeconds(0.8f);
        glifo.SetActive(true);
        glifoBtn.enabled = true;
    }
}
