using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections.Generic;

public class DialogosManager : MonoBehaviour
{
    [Header("UI Dialogo")]
    public TextMeshProUGUI dialogoText;

    [Header("Dialogo Animator")]
    [SerializeField] private Animator dialogoAnimator;

    [Header("Elementos de audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip avanzarDialogoAudio;

    //Historia actual que se esta leyendo
    private Story historiaActual;

    //Parrafo actual
    public int parrafoActual = 0;

    public bool dialogoActivo { get; private set; }

    private static DialogosManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Instancias multiples");
        }
        instance = this;
    }

    public static DialogosManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogoActivo = false;
    }

    public void Update()
    {
        //Si no hay dialogo activo, no hacer nada
        if (!dialogoActivo)
        {
            return;
        }

        //Si hay dialogo activo, mostrar el dialogo y avanzar con spacebar
        if (dialogoActivo && Input.GetKeyDown(KeyCode.Space))
        {
            ContinuarHistoria();
            parrafoActual++;
            Debug.Log("Parrafo actual: " + parrafoActual);
            audioSource.PlayOneShot(avanzarDialogoAudio);
        }
    }

    public void IniciarDialogo(TextAsset inkJSON)
    {
        audioSource.PlayOneShot(avanzarDialogoAudio);
        parrafoActual = 0;
        historiaActual = new Story(inkJSON.text);
        dialogoActivo = true;

        ContinuarHistoria();
    }

    private void SalirDialogo()
    {
        dialogoActivo = false;
        dialogoText.text = string.Empty;
        dialogoAnimator.SetBool("MostrarDialogo", false);
    }

    public void ContinuarHistoria()
    {
        if (historiaActual.canContinue)
        {
            dialogoText.text = historiaActual.Continue();
        }
        else
        {
            SalirDialogo();
        }
    }
}
