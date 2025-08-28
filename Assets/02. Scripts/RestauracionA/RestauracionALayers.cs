using UnityEngine;

public class RestauracionALayers : MonoBehaviour
{
    [Header("Sprite Jose")]
    [SerializeField] SpriteRenderer joseSprite;

    private void Start()
    {
        joseSprite.sortingOrder = 2;
    }

    //Si hace trigger con player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            joseSprite.sortingOrder = 4;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            joseSprite.sortingOrder = 2;
        }
    }

}
