using UnityEngine;

public class Drop : MonoBehaviour, CardArea
{
    // Metodo que se llama cuando una carta es soltada en esta área
    public void OnCardDrop(Drag card)
    {
        card.transform.position = transform.position;
    }
}
