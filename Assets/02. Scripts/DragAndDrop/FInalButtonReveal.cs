using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class FInalButtonReveal : MonoBehaviour
{
    [Header("Boton Final para poner peso")]
    public Button botonFinal;

    private void Update()
    {
        if (Drop.parchesPegados == 4)
        {
            botonFinal.gameObject.SetActive(true);
        }
        else
        {
            botonFinal.gameObject.SetActive(false);
        }
    }
}
