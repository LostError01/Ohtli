
using Ink.Parsed;
using System.Collections.Generic;
using UnityEngine;

public class juego : MonoBehaviour
{
    [SerializeField]
    private control _Prefab;
    [SerializeField]
    private float tamaño = 4f;
    private List<control> _cartas = new List<control>();
    private int columnas =4;
    private int filas =4;
     
    public void start()
    {
        _cartas.ForEach(c => Destroy(c.gameObject));
        _cartas.Clear();
        Vector3 offset = new Vector3((columnas - 1) * tamaño, (filas - 1) * tamaño, 0) * 0.5f;
        for (int i = 0; i < filas; i++)
        {
            for(int j = 0; j < columnas; j++)
            {
                Vector3 posicion = new Vector3(i * tamaño, j * tamaño, 0f);
        var card = Instantiate(_Prefab, posicion - offset, Quaternion.identity);
                card.tipo = i;
                card.OnClicked.AddListener(oncardcliked);
                _cartas.Add(card);
                
            }
                
        }
    }
    public void oncardcliked(control card)
    {
        card.test();
    }
    void Start() 
    {   
        start();
    }

    
    void Update()
    {
        
    }
}
