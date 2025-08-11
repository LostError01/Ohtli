using UnityEngine;

public class PlayerMetzBiblio : MonoBehaviour
{
    public float speed = 4f;
    Animator anim;
    Rigidbody2D prb;
    Vector2 mov;

    private bool dialogo = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        prb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mov = new Vector2(//WASD diagonales
         Input.GetAxisRaw("Horizontal"),
         Input.GetAxisRaw("Vertical"));
        if (mov != Vector2.zero && !dialogo) //! diferente
        {
            anim.SetFloat("MovX", mov.x);//izq der
            anim.SetFloat("MovY", mov.y);//arriba ab
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
    void FixedUpdate()
    {
        if (DialogosManager.GetInstance().dialogoActivo)
        {
            dialogo = true;
            prb.linearVelocity = Vector2.zero;
            return;
        }
        else
        {
            dialogo = false;
            prb.MovePosition
            (prb.position + mov * speed * Time.deltaTime);
        }
    }
}