using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using System.Collections;

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
        pantalla01Canvas.gameObject.SetActive(true);
        pantalla02Canvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(camaraAnimator.GetInteger("Pantalla") == 0)
        {
            StartCoroutine(MostrarPantalla0());
        }

        if(camaraAnimator.GetInteger("Pantalla") == 1)
        {
            StartCoroutine(MostrarPantalla1());
        }
    }

    private IEnumerator MostrarPantalla0()
    {
        pantalla02Canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        pantalla01Canvas.gameObject.SetActive(true);
    }

    private IEnumerator MostrarPantalla1()
    {
        pantalla01Canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        pantalla02Canvas.gameObject.SetActive(true);
    }
}
