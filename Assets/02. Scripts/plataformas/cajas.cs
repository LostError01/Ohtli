using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class cajas : MonoBehaviour
{
    public float pushSpeed = 3f;
    private Rigidbody2D rb;
    private Collider2D boxCollider;
    private GameObject player;
    public float pushDistance = 2f; // distancia máxima para poder empujar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player == null) return;

        
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance <= pushDistance)
        {
            
            if (Input.GetKey(KeyCode.M))
            {
               
                float dir = Mathf.Sign(player.transform.position.x - transform.position.x);

            
                rb.linearVelocity = new Vector2(-dir * pushSpeed, rb.linearVelocity.y);
                return;
            }
        }

        
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
}