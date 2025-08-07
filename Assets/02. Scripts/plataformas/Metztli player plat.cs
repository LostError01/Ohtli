using UnityEngine;

public class MetztliPlayerPlat : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    Animator Panim;

    [Header("Movement Settings")]
    public float PSpeed = 6f;
    public float jumpPower = 7f;

    [Header("Ground & Wall Detection")]
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundLayer;
    private bool isGround;
    private bool isWall;
    private bool jumped;
    private bool wasWall; // detectar entrada a pared

    [Header("Wall Mechanics")]
    public float wallSlideSpeed = 1.5f;  // velocidad de deslizamiento
    private bool isWallSliding;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        Panim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckIfGrounded();
        CheckIfWalled();
        HandleWallSlide();
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        // ✅ Si hay pared y el jugador intenta avanzar hacia ella
        if ((h > 0 && isWall && transform.localScale.x > 0) ||
            (h < 0 && isWall && transform.localScale.x < 0))
        {
            h = 0;
        }

        // ✅ Si toca la pared por primera vez, micro desplazamiento anti-stick
        if (isWall && !wasWall)
        {
            Vector2 pushDir = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
            PlayerRB.position += pushDir * 0.02f;
        }
        wasWall = isWall;

        // ✅ Movimiento horizontal normal (no afecta wall slide)
        if (!isWallSliding)
        {
            PlayerRB.linearVelocity = new Vector2(h * PSpeed, PlayerRB.linearVelocity.y);
        }

        // Cambiar dirección sprite
        if (h != 0) ChangeDirection((int)Mathf.Sign(h));

        // Animación caminar
        Panim.SetInteger("Speed", Mathf.Abs((int)PlayerRB.linearVelocity.x));
    }

    void ChangeDirection(int dir)
    {
        Vector3 scale = transform.localScale;
        scale.x = dir;
        transform.localScale = scale;
    }

    void CheckIfGrounded()
    {
        isGround = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayer);

        if (isGround && jumped)
        {
            jumped = false;
            Panim.SetTrigger("Jump");
        }
    }

    void CheckIfWalled()
    {
        Vector2 dir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        isWall = Physics2D.Raycast(wallCheck.position, dir, 0.1f, groundLayer);
    }

    void HandleWallSlide()
    {
        // ✅ Activa wall slide solo si está tocando pared, no está en el suelo y cae
        if (isWall && !isGround && PlayerRB.linearVelocity.y < 0)
        {
            isWallSliding = true;
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, -wallSlideSpeed);
        }
        else
        {
            isWallSliding = false;
        }
    }

    void PlayerJump()
    {
        // ✅ Salto normal (sin wall jump)
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, jumpPower);
            Panim.SetTrigger("Jump");
        }
    }
}
