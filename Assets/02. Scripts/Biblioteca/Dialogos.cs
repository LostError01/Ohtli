using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogos : MonoBehaviour
{
    [Header("Archivo de Ink (Dialogo)")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset inkJSON2;

    [Header("Script de Dialogo que se quiere modificar")]
    [SerializeField] private DialogosManager dialogosManager;

    [Header("Dialogo Animator")]
    [SerializeField] private Animator dialogoAnimator;

    [Header("Anim Personaje 2")]
    [SerializeField] private Animator mobilePJ2;


    [Header("Imagen Metztli")]
    [SerializeField] Image MetztliImg;

    [Header("Imagen Jose")]
    [SerializeField] Image JoseImg;

    [Header("Animator Personaje 1")]
    [SerializeField] Animator PJ1Animator;

    [Header("Animator Personaje 2")]
    [SerializeField] Animator mobilePJ2Animator;

    //VARIABLE PARA SABER SI EL JUGADOR ESTÁ EN EL TRIGGER
    private bool playerInTrigger = false;

    //VARIABLES DE ANIMATOR DE ANIMALES
    private Animator serpienteAnimator;
    private Animator aranaAnimator;
    private Animator chapulinAnimator;

    private bool aguilaTeclaE = false;

    //VARIABLES DE CONTROL DE ANIMALES
    public static int animalesContador = 0;

    private void Start()
    {
        if(this.gameObject.name == "JoseArea")
        {
            MetztliImg.enabled = false;
            JoseImg.enabled = true;
        }

        animalesContador = 0;
    }

    public void Update()
    {
        if (animalesContador == 3 && SceneManager.GetActiveScene().name == "Boturini RPG")
        {
            Debug.Log("Ya encontraste los 3 animales");
        }


        //Lobby
        if (playerInTrigger && this.gameObject.name == "JoseLobbyArea")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Jose");
                PJ1Animator.SetTrigger("Metztli");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 3)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 5)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }
            if (dialogosManager.parrafoActual == 7)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 8)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }

            //Acabar el dialogo
            if(dialogosManager.parrafoActual == 10)
            {
                SceneManager.LoadScene("E1");
            }
        }

        //Escena biblioteca
        if (playerInTrigger && this.gameObject.name == "JoseArea")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
                dialogoAnimator.SetBool("MostrarDialogo",true);
                mobilePJ2Animator.SetTrigger("Jose");
                PJ1Animator.SetTrigger("Metztli");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if(dialogosManager.parrafoActual == 2)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;
                //Cambia el alignment a la derecha
                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if(dialogosManager.parrafoActual == 3)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment= TMPro.HorizontalAlignmentOptions.Left;
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }
        
        //Restauracion Version normal
        if (playerInTrigger && this.gameObject.name == "JoseRestauracionA")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Jose");
                PJ1Animator.SetTrigger("MetztliCubrebocas");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 3)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 6)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }
            if (dialogosManager.parrafoActual == 9)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
        }

        //Restauracion Version Distorsionada
        if (playerInTrigger && this.gameObject.name == "ZiloRestauracionB")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Zilo");
                PJ1Animator.SetTrigger("MetztliCubrebocas");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 2)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 4)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }
            if (dialogosManager.parrafoActual == 5)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 7)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }

            if(dialogosManager.parrafoActual == 11)
            {
                SceneManager.LoadScene("E1");
            }
        }


        //Zilo en el codice Boturini

        if (playerInTrigger && this.gameObject.name == "ZiloAreaCodice")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Zilo");
                PJ1Animator.SetTrigger("Metztli");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 2)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 4)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }
        }

        //Dialogo Serpiente

        if (playerInTrigger && this.gameObject.name == "DialogSerpiente")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Serpiente());
            }
        }

        //Dialogo Arana

        if (playerInTrigger && this.gameObject.name == "DialogArana")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Arana());
            }
        }

        //Dialogo Chapulin

        if (playerInTrigger && this.gameObject.name == "DialogChapulin")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Chapulin());
            }
        }

        //Dialogo Zilo Codice Mendoza

        if (playerInTrigger && this.gameObject.name == "ZiloMendozaCodice")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Zilo");
                PJ1Animator.SetTrigger("Metztli");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 3)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 5)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }
        }

        //Dialogo Serpiente 02

        if (playerInTrigger && this.gameObject.name == "DialogSerpiente02")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Serpiente02());
            }
        }

        //Dialogo Chapulin

        if (playerInTrigger && this.gameObject.name == "DialogChapulin02")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Chapulin02());
            }
        }

        //Dialogo Pez

        if (playerInTrigger && this.gameObject.name == "DialogPez")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Pez());
            }
        }

        //Dialogo Pavo

        if (playerInTrigger && this.gameObject.name == "DialogPavo")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Pavo());
            }
        }

        //Dialogo Aldeano

        if (playerInTrigger && this.gameObject.name == "DialogAldeano")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
                JoseImg.enabled = false;
                MetztliImg.enabled = false;
                dialogoAnimator.SetBool("MostrarDialogo", true);
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }
        }

        //Dialogo Aguila

        if (playerInTrigger && this.gameObject.name == "DialogAguila")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (animalesContador == 4)
                {
                    dialogoAnimator.SetBool("MostrarDialogo", true);
                    JoseImg.enabled = false;
                    MetztliImg.enabled = false;
                    DialogosManager.GetInstance().IniciarDialogo(inkJSON);
                    aguilaTeclaE = true;
                }
                else
                {
                    dialogoAnimator.SetBool("MostrarDialogo", true);
                    JoseImg.enabled = false;
                    MetztliImg.enabled = false;
                    DialogosManager.GetInstance().IniciarDialogo(inkJSON2);
                }
            }

            if (!dialogosManager.dialogoActivo && aguilaTeclaE)
            {
                GameObject chapulin = GameObject.Find("aguila");
                this.GetComponent<Collider2D>().enabled = false;
                chapulinAnimator = chapulin.GetComponent<Animator>();
                chapulinAnimator.SetBool("Desaparecer", true);
                StartCoroutine(Aguila());
                aguilaTeclaE = false;
            }
        }

        //Dialogo Huitzilopochtli

        if (playerInTrigger && this.gameObject.name == "DiosDialog")
        {
            GameObject fondoDialogo = GameObject.Find("FondoDialogo");
            GameObject texto = GameObject.Find("Texto");

            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Dios");
                PJ1Animator.SetTrigger("Metztli");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 2 || dialogosManager.parrafoActual == 10 || dialogosManager.parrafoActual == 16
                || dialogosManager.parrafoActual == 19 || dialogosManager.parrafoActual == 25)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;
                fondoDialogo.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                texto.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f);

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 7 || dialogosManager.parrafoActual == 13 || dialogosManager.parrafoActual == 17
                || dialogosManager.parrafoActual == 22 || dialogosManager.parrafoActual == 27)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;
                fondoDialogo.GetComponent<Image>().color = new Color(0.5f, 0.3f, 0.4f);
                texto.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0.9f, 0.6f, 0f);

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }

            if(dialogosManager.parrafoActual == 28)
            {
                SceneManager.LoadScene("E1");
            }
        }

        //Dialogo Jose Lobby B

        //Dialogo Zilo Codice Mendoza

        if (playerInTrigger && this.gameObject.name == "JoseLobbyB")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                mobilePJ2Animator.SetTrigger("Jose");
                PJ1Animator.SetTrigger("Metztli");
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
            }

            if (dialogosManager.parrafoActual == 2 || dialogosManager.parrafoActual == 6)
            {
                JoseImg.enabled = false;
                MetztliImg.enabled = true;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Right;
            }
            if (dialogosManager.parrafoActual == 4)
            {
                JoseImg.enabled = true;
                MetztliImg.enabled = false;

                dialogosManager.dialogoText.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Left;
            }

            if(dialogosManager.parrafoActual == 8)
            {
                SceneManager.LoadScene("E1");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Entra al diálogo
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Sale del diálogo
            playerInTrigger = false;
        }
    }

    //IEnumerators para animales

    IEnumerator Serpiente()
    {
        //Encontrar gameobject de la serpiente y extraer su animator
        GameObject serpiente = GameObject.Find("Serpiente_01");
        serpienteAnimator = serpiente.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false;
        serpienteAnimator.SetBool("Desaparecer", true); 
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que el diálogo termine antes de sumar
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        // Incrementar contador solo si aún no ha sido contado
        if (animalesContador < 3)
        {
            animalesContador++;
        }
    }

    IEnumerator Arana()
    {
        GameObject arana = GameObject.Find("Arana_01");
        aranaAnimator = arana.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false;
        aranaAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que el diálogo termine antes de sumar
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        // Incrementar contador solo si aún no ha sido contado
        if (animalesContador < 3)
        {
            animalesContador++;
        }
    }

    IEnumerator Chapulin()
    {
        GameObject chapulin = GameObject.Find("Chapulin_01");
        aranaAnimator = chapulin.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false;
        aranaAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que el diálogo termine antes de sumar
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        // Incrementar contador solo si aún no ha sido contado
        if (animalesContador < 3)
        {
            animalesContador++;
        }
    }

    /// VERSION DE MENDOZA

    IEnumerator Serpiente02()
    {
        GameObject serpiente = GameObject.Find("vibora");
        serpienteAnimator = serpiente.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false; // Evita repetir
        serpienteAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que el diálogo termine antes de sumar
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        // Incrementar contador solo si aún no ha sido contado
        if (animalesContador < 4)
        {
            animalesContador++;
        }
    }

    IEnumerator Chapulin02()
    {
        GameObject chapulin = GameObject.Find("chapulin02");
        chapulinAnimator = chapulin.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false;
        chapulinAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que termine el diálogo
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        if (animalesContador < 4)
        {
            animalesContador++;
        }
    }

    IEnumerator Pez()
    {
        GameObject pez = GameObject.Find("pez");
        Animator pezAnimator = pez.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false;
        pezAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que termine
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        if (animalesContador < 4)
        {
            animalesContador++;
        }
    }

    IEnumerator Pavo()
    {
        GameObject pavo = GameObject.Find("pavo");
        Animator pavoAnimator = pavo.GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = false;
        pavoAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);

        // Esperar a que termine
        while (dialogosManager.dialogoActivo)
        {
            yield return null;
        }

        if (animalesContador < 4)
        {
            animalesContador++;
        }
    }

    IEnumerator Aguila()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("E1");
    }
}
