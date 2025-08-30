using UnityEngine;

public class MetztliRPGboturini : MonoBehaviour
{
    public float speed = 4f;
    Animator anim;
    Rigidbody2D prb;
    Vector2 mov;
    CircleCollider2D AttackCollider;//<<<<<<<

    [Header("Script Dialogos Manager")]
    [SerializeField] private DialogosManager dialogosManager;

    [Header("Elementos de Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ataqueAudio;


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
        if(dialogosManager.dialogoActivo)
        {
            mov = Vector2.zero;
            anim.SetBool("walking", false);
            return;
        }

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
        stateInfo.IsName("MB_Attack");
        // Ataque con espacio
        if (Input.GetMouseButtonDown(1) && !attacking)
        {
            anim.SetTrigger("Attacking");
            audioSource.PlayOneShot(ataqueAudio);
        }
        if (mov != Vector2.zero)
            AttackCollider.offset =
            new Vector2(mov.x / 2, mov.y / 2);
        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            //Mientras se esta atacando no se puede mover
            mov = Vector2.zero;
            if (playbackTime > 0.2 && playbackTime < 0.6) 
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