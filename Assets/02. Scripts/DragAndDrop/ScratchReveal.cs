using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Collections;
using Ink.Parsed;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ScratchReveal : MonoBehaviour
{
    [Header("Luz de la pantalla")]
    [SerializeField] private Light2D luzPantalla;

    [Header("Collider Hoja de papel")]
    [SerializeField] private Collider2D hojaPapel;

    [Header("Animator Hoja")]
    [SerializeField] private Animator hojaAnim;

    [Header("Ventana de aviso")]
    [SerializeField] private TextMeshProUGUI avisoTexto;
    [SerializeField] private Animator avisoAnim;

    [Header("Botones para pegar parches")]
    [SerializeField] private List<Button> botonesPegarParche = new List<Button>();

    //Bandera para pincel
    private bool pincelClickeado = false;

    //Bandera para ver si ya se limpio la hoja
    private bool hojaLimpiada = false;

    //Roturas del documento
    private GameObject scratch01;
    private GameObject scratch02;
    private GameObject scratch03;
    private GameObject scratch04;

    //Flag para ver si se ha detectado un clic en Scratch01
    private bool scratch01Clicked = false;
    private bool scratch02Clicked = false;
    private bool scratch03Clicked = false;
    private bool scratch04Clicked = false;

    //Luz encendida
    public static bool luzEncendida = false;

    private void Start()
    {

        //Encontrar los objetos de rotura del documento con los tags correspondientes
        scratch01 = GameObject.FindGameObjectWithTag("Scratch01");
        scratch02 = GameObject.FindGameObjectWithTag("Scratch02");
        scratch03 = GameObject.FindGameObjectWithTag("Scratch03");
        scratch04 = GameObject.FindGameObjectWithTag("Scratch04");

        //Desactivar los objetos de rotura al inicio
        if (scratch01 != null) scratch01.SetActive(false);
        if (scratch02 != null) scratch02.SetActive(false);
        if (scratch03 != null) scratch03.SetActive(false);
        if (scratch04 != null) scratch04.SetActive(false);

        //Desactivar los botones de pegar parches al inicio
        foreach (Button btn in botonesPegarParche)
        {
            btn.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (luzPantalla.intensity == 2.0)
        {
            luzEncendida = true;

            //Cuando la luz de pantalla se encienda, activar
            if (!scratch01Clicked)
            {
                scratch01.SetActive(true);
            }
            if (!scratch02Clicked)
            {
                scratch02.SetActive(true);
            }
            if (!scratch03Clicked)
            {
                scratch03.SetActive(true);
            }
            if (!scratch04Clicked)
            {
                scratch04.SetActive(true);
            }
        }
        else
        {
            luzEncendida = false;

            //Cuando la luz de pantalla se apague, desactivar
            if (!scratch01Clicked)
                scratch01.SetActive(false);
            if(!scratch02Clicked)
                scratch02.SetActive(false);
            if(!scratch03Clicked)
                scratch03.SetActive(false);
            if(!scratch04Clicked)
                scratch04.SetActive(false);
        }

        //Si se hace clic y la hoja ya ha sido limpiada
        if (Input.GetMouseButtonDown(0) && hojaLimpiada)
        {
            //Funciones para detectar si se ha hecho clic en algunos de los objetos de rotura
            if (scratch01.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                //No solapamiento de herramientas
                if (ButtonFunctions.brochaSeleccionada || ButtonFunctions.bisturiSeleccionado || ButtonFunctions.pincelSeleccionado)
                {
                    avisoTexto.text = "Tiene una herramienta seleccionada, deseleccionela para poder marcar las roturas";
                    StartCoroutine(MostrarAviso());
                }
                else if (!ButtonFunctions.brochaSeleccionada && !ButtonFunctions.bisturiSeleccionado && !ButtonFunctions.pincelSeleccionado)
                { 
                scratch01Clicked = true;
                scratch01.SetActive(true);
                scratch01.GetComponent<Collider2D>().enabled = false;
                }
            }

            if (scratch02.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                //No solapamiento de herramientas
                if (ButtonFunctions.brochaSeleccionada || ButtonFunctions.bisturiSeleccionado || ButtonFunctions.pincelSeleccionado)
                {
                    avisoTexto.text = "Tiene una herramienta seleccionada, deseleccionela para poder marcar las roturas";
                    StartCoroutine(MostrarAviso());
                }
                else if (!ButtonFunctions.brochaSeleccionada && !ButtonFunctions.bisturiSeleccionado && !ButtonFunctions.pincelSeleccionado)
                {
                    scratch02Clicked = true;
                    scratch02.SetActive(true);
                    scratch02.GetComponent<Collider2D>().enabled = false;
                }
            }

            if (scratch03.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                //No solapamiento de herramientas
                if (ButtonFunctions.brochaSeleccionada || ButtonFunctions.bisturiSeleccionado || ButtonFunctions.pincelSeleccionado)
                {
                    avisoTexto.text = "Tiene una herramienta seleccionada, deseleccionela para poder marcar las roturas";
                    StartCoroutine(MostrarAviso());
                }
                else if (!ButtonFunctions.brochaSeleccionada && !ButtonFunctions.bisturiSeleccionado && !ButtonFunctions.pincelSeleccionado)
                {
                    scratch03Clicked = true;
                    scratch03.SetActive(true);
                    scratch03.GetComponent<Collider2D>().enabled = false;
                }
            }

            if (scratch04.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                //No solapamiento de herramientas
                if (ButtonFunctions.brochaSeleccionada || ButtonFunctions.bisturiSeleccionado || ButtonFunctions.pincelSeleccionado)
                {
                    avisoTexto.text = "Tiene una herramienta seleccionada, deseleccionela para poder marcar las roturas";
                    StartCoroutine(MostrarAviso());
                }
                else if (!ButtonFunctions.brochaSeleccionada && !ButtonFunctions.bisturiSeleccionado && !ButtonFunctions.pincelSeleccionado)
                {
                    scratch04Clicked = true;
                    scratch04.SetActive(true);
                    scratch04.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
        else if (Input.GetMouseButtonDown(0) && !hojaLimpiada)
        {
            //Limpieza de hoja
            if (ButtonFunctions.brochaSeleccionada && hojaPapel.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                hojaLimpiada = true;
                hojaPapel.enabled = false;
                avisoTexto.text = "Hoja limpiada,ahora puede marcar las roturas";
                hojaAnim.SetBool("Limpiar",true);
                StartCoroutine(MostrarAviso());
            }
            else if (!ButtonFunctions.brochaSeleccionada && hojaPapel.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                avisoTexto.text = "Primero necesita limpiar la hoja con la brocha";
                StartCoroutine(MostrarAviso());
            }
        }

        //Si se han marcado todas las roturas
        if (scratch01Clicked && scratch02Clicked && scratch03Clicked && scratch04Clicked)
        {
            //Si se tiene el pincel seleccionado, mostrar aviso
            if (ButtonFunctions.pincelSeleccionado && !pincelClickeado)
            {
                avisoTexto.text = "Pincel seleccionado: Haga click sobre las roturas y pegue los parches antes de que el pegamento seque";
                StartCoroutine(MostrarAviso());
                pincelClickeado = true;
            }

            if(!ButtonFunctions.pincelSeleccionado)
            {
                pincelClickeado = false;
            }
        }

        if(scratch01Clicked)
        {
            botonesPegarParche[0].gameObject.SetActive(true);
        }
        if(scratch02Clicked)
        {
            botonesPegarParche[1].gameObject.SetActive(true);
        }
        if(scratch03Clicked)
        {
            botonesPegarParche[2].gameObject.SetActive(true);
        }
        if(scratch04Clicked)
        {
            botonesPegarParche[3].gameObject.SetActive(true);
        }
    }

    private IEnumerator MostrarAviso()
    {
        avisoAnim.SetBool("Start", true);
        yield return new WaitForSeconds(4f);
        avisoAnim.SetBool("Start", false);
    }

    //Metodos de botones para pegar los parches

    public void PegarParche01()
    {
        if (ButtonFunctions.pincelSeleccionado)
        {
                botonesPegarParche[0].gameObject.SetActive(false);
                avisoTexto.text = "Parche 1 con pegamento, ahora puede arrastrar el parche";
                scratch01.GetComponent<Collider2D>().enabled = true;
                //Cambiar a color dado en rgb
                scratch01.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.6f, 0.7f);
                StartCoroutine(MostrarAviso());
        }
        else
        {
            avisoTexto.text = "Primero debe seleccionar el pincel para pegar los parches";
            StartCoroutine(MostrarAviso());
        }
    }

    public void PegarParche02()
    {
        if (ButtonFunctions.pincelSeleccionado)
        {
            botonesPegarParche[1].gameObject.SetActive(false);
            avisoTexto.text = "Parche 2 con pegamento, ahora puede arrastrar el parche";
            scratch02.GetComponent<Collider2D>().enabled = true;
            scratch02.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.6f, 0.7f);
            StartCoroutine(MostrarAviso());
        }
        else
        {
            avisoTexto.text = "Primero debe seleccionar el pincel para pegar los parches";
            StartCoroutine(MostrarAviso());
        }
    }

    public void PegarParche03()
    {
        if (ButtonFunctions.pincelSeleccionado)
        {
            botonesPegarParche[2].gameObject.SetActive(false);
            avisoTexto.text = "Parche 3 con pegamento, ahora puede arrastrar el parche";
            scratch03.GetComponent<Collider2D>().enabled = true;
            scratch03.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.6f, 0.7f);
            StartCoroutine(MostrarAviso());
        }
        else
        {
            avisoTexto.text = "Primero debe seleccionar el pincel para pegar los parches";
            StartCoroutine(MostrarAviso());
        }
    }

    public void PegarParche04()
    {
        if (ButtonFunctions.pincelSeleccionado)
        {
            botonesPegarParche[3].gameObject.SetActive(false);
            avisoTexto.text = "Parche 4 con pegamento, ahora puede arrastrar el parche";
            scratch04.GetComponent<Collider2D>().enabled = true;
            scratch04.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.6f, 0.7f);
            StartCoroutine(MostrarAviso());
        }
        else
        {
            avisoTexto.text = "Primero debe seleccionar el pincel para pegar los parches";
            StartCoroutine(MostrarAviso());
        }
    }
}
