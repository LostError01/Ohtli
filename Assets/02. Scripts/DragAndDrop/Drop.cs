using UnityEngine;

public class Drop : MonoBehaviour, CardArea
{
    public void OnCardDrop(Drag card)
    {
        card.transform.position = transform.position;
    }
}
