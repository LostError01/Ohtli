using UnityEngine;

public class MetztliRPGboturini : MonoBehaviour
{
    public float speed = 4f;
    Animator anim;
    Rigidbody2D prb;
    Vector2 mov;
    CircleCollider2D AttackCollider;//<<<<<<<

    void Start()
    {
        anim = GetComponent<Animator>();
        prb = GetComponent<Rigidbody2D>();
        AttackCollider =
        transform.GetChild(0).GetComponent
        <CircleCollider2D>();
        AttackCollider.enabled = false;
    }
    void Update()
    {
        mov = new Vector2(//WASD diagonales
         Input.GetAxisRaw("Horizontal"),
         Input.GetAxisRaw("Vertical"));
        if (mov != Vector2.zero) //! diferente
        {
            anim.SetFloat("MovX", mov.x);//izq der
            anim.SetFloat("MovY", mov.y);//arriba ab
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        AnimatorStateInfo stateInfo =
        anim.GetCurrentAnimatorStateInfo(0);
        bool attacking =
        stateInfo.IsName("MB_Attack"); // tree
        if (Input.GetKeyDown("space") && !attacking) // comprobación 
        {
            anim.SetTrigger("Attacking");
        }
        if (mov != Vector2.zero)
            AttackCollider.offset =
            new Vector2(mov.x / 2, mov.y / 2);// -x -y
        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.2 && playbackTime < 0.6) //<<<<
            {
                AttackCollider.enabled = true;
            }
            else
            {
                AttackCollider.enabled = false;//ocultar ataque
            }
        }
    }
    void FixedUpdate()
    {
        prb.MovePosition
        (prb.position + mov * speed * Time.deltaTime);
    }
}