using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMetzBiblio : MonoBehaviour
{
    public float speed = 4f;
    Animator anim;
    Rigidbody2D prb;
    Vector2 mov;

    private bool dialogo = false;
    private bool herramientaRecogida01 = false;
    public bool herramientaRecogida02 = false;
    public bool herramientaRecogida03 = false;

    [Header("Elemento de Audio")]
    [SerializeField] private AudioSource audioSource;

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

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                audioSource.loop = true;
            }
        }
        else
        {
            anim.SetBool("walking", false);

            audioSource.Stop();
        }

        if(herramientaRecogida01 && herramientaRecogida02 && herramientaRecogida03)
        {
            SceneManager.LoadScene("zonarestauracion");
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

    //Teletransporte a algunas escenas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleport") && SceneManager.GetActiveScene().name == "zonarestauracion")
        {
           SceneManager.LoadScene("E1"); //Debe mandar a E3 cuando este lista
        }

        if(collision.CompareTag("Herramienta") && SceneManager.GetActiveScene().name == "biblioteca")
        {
            herramientaRecogida01 = true;
            //Destruir el objeto herramienta
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Herramienta2") && SceneManager.GetActiveScene().name == "biblioteca")
        {
            herramientaRecogida02 = true;
            //Destruir el objeto herramienta
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Herramienta3") && SceneManager.GetActiveScene().name == "biblioteca")
        {
            herramientaRecogida03 = true;
            //Destruir el objeto herramienta
            Destroy(collision.gameObject);
        }
    }
}