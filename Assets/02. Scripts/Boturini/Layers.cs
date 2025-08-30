using UnityEngine;

public class Layers : MonoBehaviour
{
    [Header("Sprite Arbol")]
    [SerializeField] SpriteRenderer arbolSprite;

    private void Start()
    {
        arbolSprite.sortingOrder = 2;
    }

    //Si hace trigger con player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            arbolSprite.sortingOrder = 4;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            arbolSprite.sortingOrder = 2;
        }
    }
}
