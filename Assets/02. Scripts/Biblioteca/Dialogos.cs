using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using System;
using TMPro;

public class Dialogos : MonoBehaviour
{
    [Header("Archivo de Ink (Dialogo)")]
    [SerializeField] private TextAsset inkJSON;

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

    private void Start()
    {
        if(this.gameObject.name == "JoseArea")
        {
            MetztliImg.enabled = false;
            JoseImg.enabled = true;
        }
    }

    private void Update()
    {
        //Lobby
        if (playerInTrigger && this.gameObject.name == "JoseLobbyArea")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
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
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Escena biblioteca
        if (playerInTrigger && this.gameObject.name == "JoseArea")
        {
            if(Input.GetKeyDown(KeyCode.E))
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
                mobilePJ2.speed = 0;
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
        else
        {
            mobilePJ2.speed = 1;
        }

        //Restauracion Version Distorsionada
        if (playerInTrigger && this.gameObject.name == "ZiloRestauracionB")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
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
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Zilo en el codice Boturini

        if (playerInTrigger && this.gameObject.name == "ZiloAreaCodice")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
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
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Serpiente

        if (playerInTrigger && this.gameObject.name == "DialogSerpiente")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Serpiente());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Arana

        if (playerInTrigger && this.gameObject.name == "DialogArana")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Arana());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Chapulin

        if (playerInTrigger && this.gameObject.name == "DialogChapulin")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Chapulin());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Zilo Codice Mendoza

        if (playerInTrigger && this.gameObject.name == "ZiloMendozaCodice")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
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
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Serpiente 02

        if (playerInTrigger && this.gameObject.name == "DialogSerpiente02")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Serpiente02());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Chapulin

        if (playerInTrigger && this.gameObject.name == "DialogChapulin02")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Chapulin02());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Pez

        if (playerInTrigger && this.gameObject.name == "DialogPez")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Pez());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Pavo

        if (playerInTrigger && this.gameObject.name == "DialogPavo")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Pavo());
            }
        }
        else
        {
            mobilePJ2.speed = 1;
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
        else
        {
            mobilePJ2.speed = 1;
        }

        // Aguila

        if (playerInTrigger && this.gameObject.name == "DialogAguila")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo", true);
                JoseImg.enabled = false;
                MetztliImg.enabled = false;
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
                aguilaTeclaE = true;
            }

            if (!dialogosManager.dialogoActivo && aguilaTeclaE)
            {
                GameObject chapulin = GameObject.Find("aguila");
                this.GetComponent<Collider2D>().enabled = false;
                chapulinAnimator = chapulin.GetComponent<Animator>();
                chapulinAnimator.SetBool("Desaparecer", true);
                aguilaTeclaE = false;
            }
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Huitzilopochtli

        if (playerInTrigger && this.gameObject.name == "DiosDialog")
        {
            GameObject fondoDialogo = GameObject.Find("FondoDialogo");
            GameObject texto = GameObject.Find("Texto");

            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
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
        }
        else
        {
            mobilePJ2.speed = 1;
        }

        //Dialogo Jose Lobby B

        //Dialogo Zilo Codice Mendoza

        if (playerInTrigger && this.gameObject.name == "JoseLobbyB")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mobilePJ2.speed = 0;
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
        }
        else
        {
            mobilePJ2.speed = 1;
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
    }

    IEnumerator Serpiente02()
    {
        //Encontrar gameobject de la serpiente y extraer su animator
        GameObject serpiente = GameObject.Find("vibora");
        this.GetComponent<Collider2D>().enabled = false;
        serpienteAnimator = serpiente.GetComponent<Animator>();
        serpienteAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);
    }

    IEnumerator Chapulin02()
    {
        GameObject chapulin = GameObject.Find("chapulin02");
        this.GetComponent<Collider2D>().enabled = false;
        chapulinAnimator = chapulin.GetComponent<Animator>();
        chapulinAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);
    }

    IEnumerator Pez()
    {
        GameObject chapulin = GameObject.Find("pez");
        this.GetComponent<Collider2D>().enabled = false;
        chapulinAnimator = chapulin.GetComponent<Animator>();
        chapulinAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);
    }

    IEnumerator Pavo()
    {
        GameObject chapulin = GameObject.Find("pavo");
        this.GetComponent<Collider2D>().enabled = false;
        chapulinAnimator = chapulin.GetComponent<Animator>();
        chapulinAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);
    }
}
