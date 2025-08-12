using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class cajas : MonoBehaviour
{
    public float pushSpeed = 3f;
    private Rigidbody2D rb;
    private Collider2D boxCollider;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Detecta si el jugador est� tocando la caja
        if (IsPlayerTouching())
        {
            // Detectar input horizontal
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput == 0)
            {
                StopMovement();
                return;
            }

            // Detecta si el jugador est� "empujando" hacia la caja
            float directionToPlayer = Mathf.Sign(player.transform.position.x - transform.position.x);

            // Si el jugador presiona en direcci�n a la caja, moverla
            if ((directionToPlayer < 0 && horizontalInput < 0) || (directionToPlayer > 0 && horizontalInput > 0))
            {
                rb.linearVelocity = new Vector2(-directionToPlayer * pushSpeed, rb.linearVelocity.y);
            }
            else
            {
                StopMovement();
            }
        }
        else
        {
            StopMovement();
        }
    }

    private bool IsPlayerTouching()
    {
        // Revisar si el jugador est� tocando la caja
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int count = boxCollider.GetContacts(contacts);

        for (int i = 0; i < count; i++)
        {
            if (contacts[i].collider != null && contacts[i].collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private void StopMovement()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
}