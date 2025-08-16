using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScratchReveal : MonoBehaviour
{
    [Header("Luz de la pantalla")]
    [SerializeField] private Light2D luzPantalla;

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
    }

    private void Update()
    {
        if(luzPantalla.intensity == 2.0)
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

        //Si se hace clic
        if (Input.GetMouseButtonDown(0))
        {
            //Funciones para detectar si se ha hecho clic en algunos de los objetos de rotura
            if (scratch01.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                scratch01Clicked = true;
                scratch01.SetActive(true);
            }

            if (scratch02.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                scratch02Clicked = true;
                scratch02.SetActive(true);
            }

            if (scratch03.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                scratch03Clicked = true;
                scratch03.SetActive(true);
            }

            if (scratch04.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                scratch04Clicked = true;
                scratch04.SetActive(true);
            }
        }

    }
}
