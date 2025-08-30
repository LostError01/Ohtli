using UnityEngine;

public class LayersBiblioteca : MonoBehaviour
{
    [Header("Datos de las capas")]
    [SerializeField] int CapaMetztliMayor;
    [SerializeField] int CapaMetztliMenor;

    SpriteRenderer metztliSprite;

    private void Start()
    {
        metztliSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    //Si el player esta haciendo trigger con el objeto, el sprite tapa al player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            metztliSprite.sortingOrder = CapaMetztliMenor;
        }
    }

    //Si el player sale del trigger, el sprite esta debajo del player
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            metztliSprite.sortingOrder = CapaMetztliMayor;
        }
    }
}
