using UnityEngine;

public class MetztliRPGboturini : MonoBehaviour
{
    public float speed = 4f;
    Animator anim;
    Rigidbody2D prb;
    Vector2 mov;
    CircleCollider2D AttackCollider;

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

        mov = new Vector2(
         Input.GetAxisRaw("Horizontal"),
         Input.GetAxisRaw("Vertical"));
        if (mov != Vector2.zero)
        {
            anim.SetFloat("MovX", mov.x);
            anim.SetFloat("MovY", mov.y);
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
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            anim.SetTrigger("Attacking");
            audioSource.PlayOneShot(ataqueAudio);
            Debug.Log("ataco");
        }
        if (mov != Vector2.zero)
            AttackCollider.offset =
            new Vector2(mov.x / 2, mov.y / 2);
        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            mov = Vector2.zero;
            if (playbackTime > 0.2 && playbackTime < 0.6) 
            {
                AttackCollider.enabled = true;
            }
            else
            {
                AttackCollider.enabled = false;
            }
        }
    }
    void FixedUpdate()
    {
        prb.MovePosition
        (prb.position + mov * speed * Time.deltaTime);
    }
}