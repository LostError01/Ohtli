using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections.Generic;

public class DialogosManager : MonoBehaviour
{
    [Header("Numero de parrafos en historia")]
    [SerializeField] private int numeroParrafos;

    [Header("UI Dialogo")]
    [SerializeField] private TextMeshProUGUI dialogoText;

    [Header("Dialogo Animator")]
    [SerializeField] private Animator dialogoAnimator;

    [Header("Decisiones UI")]
    [SerializeField] private GameObject[] decisiones;

    [Header("Respuestas Animator")]
    [SerializeField] private Animator decisionesAnimator;

    //Arreglo de Textos para las decisiones
    private TextMeshProUGUI[] decisionesText;

    //Historia actual que se esta leyendo
    private Story historiaActual;

    //Parrafo actual
    private int parrafoActual = 0;

    //Variable para saber si se ha elegido una decision
    private bool DecisionTomada = false;

    //Bloqueo de spacebar mientras se toma una decision
    private bool bloqueoSpacebar = false;

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

        decisionesText = new TextMeshProUGUI[decisiones.Length];
        int index = 0;
        foreach (GameObject decision in decisiones)
        {
            decisionesText[index] = decision.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //Si no hay dialogo activo, no hacer nada
        if (!dialogoActivo)
        {
            return;
        }

        //Si hay dialogo activo, mostrar el dialogo y avanzar con spacebar
        if (dialogoActivo && Input.GetKeyDown(KeyCode.Space) && !bloqueoSpacebar)
        {
            ContinuarHistoria();
            parrafoActual++;
            Debug.Log("Parrafo actual: " + parrafoActual);
        }

        //Si es el ultimo parrafo, mostrar las decisiones
        if (parrafoActual == numeroParrafos - 1)
        {
            decisionesAnimator.SetBool("MostrarRespuestas", true);
        }
        //Si ya se ha tomado una decision, ocultar las decisiones
        if (DecisionTomada)
        {
            decisionesAnimator.SetBool("MostrarRespuestas", false);
        }

        //Bloquear spacebar si las decisiones estan visibles
        if (decisionesAnimator.GetBool("MostrarRespuestas") == true)
        {
            bloqueoSpacebar = true;
        }
        else
        {
            bloqueoSpacebar = false;
        }
    }

    public void IniciarDialogo(TextAsset inkJSON)
    {
        DecisionTomada = false;
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

    private void ContinuarHistoria()
    {
        if (historiaActual.canContinue)
        {
            dialogoText.text = historiaActual.Continue();
            MostrarDecisiones();
        }
        else
        {
            SalirDialogo();
        }


    }

    private void MostrarDecisiones()
    {
        List<Choice> decisionesActuales = historiaActual.currentChoices;

        if (decisionesActuales.Count > decisiones.Length)
        {
            Debug.LogError("No hay suficientes botones para las decisiones");
        }

        int index = 0;

        foreach (Choice decision in decisionesActuales)
        {
            decisiones[index].SetActive(true);
            decisionesText[index].text = decision.text;
            index++;
        }

        for (int i = index; i < decisiones.Length; i++)
        {
            decisiones[i].SetActive(false);
        }
    }

    public void DecisionElegida(int index)
    {   
        historiaActual.ChooseChoiceIndex(index);
        dialogoText.text = historiaActual.Continue();
        DecisionTomada = true;
        bloqueoSpacebar = false;
    }
}
