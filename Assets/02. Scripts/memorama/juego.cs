
using Ink.Parsed;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class juego : MonoBehaviour
{
    [SerializeField]
    private control _Prefab;
    [SerializeField]
    private float tamaño = 4f;
    [SerializeField]
    private int pares = 8;
    private List<control> _cartas = new List<control>();
    private int columnas = 4;
    private int filas = 4;
    private control carta1;

    public void start()
    {
        if (pares > 8)
        {
            Debug.Assert(false);
            pares = math.min(pares, 8);
        }
        List<int> todos = new List<int>();
        for (int i = 0; i < 8; ++i)
        {
            todos.Add(i);
        }
        List<int> gametodos = new List<int>();
        for (int i = 0; i < pares; ++i)
        {
            int escoger = todos[UnityEngine.Random.Range(0, todos.Count)];
            todos.Remove(escoger);
            gametodos.Add(escoger);
            gametodos.Add(escoger);
        }
        Debug.Assert((filas * columnas) % 2 == 0);
        _cartas.ForEach(c => Destroy(c.gameObject));
        _cartas.Clear();
        Vector3 offset = new Vector3((columnas - 1) * tamaño, (filas - 1) * tamaño, 0) * 0.5f;
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Vector3 posicion = new Vector3(i * tamaño, j * tamaño, 0f);
                var card = Instantiate(_Prefab, posicion - offset, Quaternion.identity);
                card.tipo = gametodos[UnityEngine.Random.Range(0, gametodos.Count)];
                gametodos.Remove(card.tipo);
                card.OnClicked.AddListener(oncardcliked);
                _cartas.Add(card);

            }

        }
    }
    public void oncardcliked(control card)
    {
        if (carta1 == null)
        {
            seleccionar(card);
            return;
        }
        if (card.tipo == carta1.tipo)
        {
            StartCoroutine(acertar(card));
            return;
        }
        StartCoroutine(fallar(card));
    }
    private void seleccionar(control card)
    {
        carta1 = card;
        carta1.Revelar();
    }
    private IEnumerator acertar(control card)
    {
        card.Revelar();
        yield return new WaitForSeconds(1f);
        _cartas.Remove(carta1);
        _cartas.Remove(card);
        Destroy(card);
        Destroy(carta1);
        carta1 = null;
    }
    private IEnumerator fallar(control card)
    {
        card.Revelar();
        yield return new WaitForSeconds(1f);
        carta1.esconder();
        card.esconder();
        carta1 = null;
    }
    void Start() 
    {   
        start();
    }
}
