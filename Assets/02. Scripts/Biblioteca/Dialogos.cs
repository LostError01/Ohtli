using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using System;

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

    [Header("Imagen Jose")]
    [SerializeField] Image JoseImg;

    [Header("Imagen Metztli")]
    [SerializeField] Image MetztliImg;

    //VARIABLE PARA SABER SI EL JUGADOR ESTÁ EN EL TRIGGER
    private bool playerInTrigger = false;

    //VARIABLES DE ANIMATOR DE ANIMALES
    private Animator serpienteAnimator;
    private Animator aranaAnimator;
    private Animator chapulinAnimator;

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
        aranaAnimator.SetBool("Desaparecer", true);
        JoseImg.enabled = false;
        MetztliImg.enabled = false;
        yield return new WaitForSeconds(2f);
        dialogoAnimator.SetBool("MostrarDialogo", true);
        DialogosManager.GetInstance().IniciarDialogo(inkJSON);
    }
}
