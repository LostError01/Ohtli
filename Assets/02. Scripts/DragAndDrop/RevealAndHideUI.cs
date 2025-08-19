using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;

public class RevealAndHideUI : MonoBehaviour
{
    [Header("Canvas Pantalla 01")]
    [SerializeField] private Canvas pantalla01Canvas;

    [Header("Canvas Pantalla 02")]
    [SerializeField] private Canvas pantalla02Canvas;

    [Header("Camara Animator")]
    [SerializeField] private Animator camaraAnimator;

    private void Start()
    {

    }
    private void Update()
    {
        if(camaraAnimator.GetInteger("Pantalla") == 0)
        {
            pantalla01Canvas.gameObject.SetActive(true);
            pantalla02Canvas.gameObject.SetActive(false);
        }

        if(camaraAnimator.GetInteger("Pantalla") == 1)
        {
            pantalla01Canvas.gameObject.SetActive(false);
            pantalla02Canvas.gameObject.SetActive(true);
        }
    }
}
