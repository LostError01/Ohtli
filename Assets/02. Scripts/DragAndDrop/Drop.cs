using UnityEngine;

public class Drop : MonoBehaviour, CardArea
{
    public static int parchesPegados = 0;

    // Metodo que se llama cuando una carta es soltada en esta área
    public void OnCardDrop(Drag card)
    {
        card.transform.position = transform.position;
        parchesPegados++;
        Debug.Log("Parches pegados: " + parchesPegados);
    }
}
