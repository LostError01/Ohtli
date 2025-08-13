using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using System;

public class Dialogos : MonoBehaviour
{
    [Header("Ink JSON Default")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Dialogo Animator")]
    [SerializeField] private Animator dialogoAnimator;

    //VARIABLE PARA SABER SI EL JUGADOR ESTÁ EN EL TRIGGER
    private bool playerInTrigger = false;

    private void Update()
    {
        if(playerInTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogoAnimator.SetBool("MostrarDialogo",true);
                DialogosManager.GetInstance().IniciarDialogo(inkJSON);
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
}
