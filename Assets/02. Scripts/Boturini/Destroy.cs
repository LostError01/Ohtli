
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Destroy : MonoBehaviour
{
    public string destroyState;//nombre
    public float timeForDisable;
    public float life =1;
    private float hit;
    Animator anim;

    [Header("HP Slider Bar")]
    [SerializeField] private Slider hpSlider;
    void Start()
    {
        anim = GetComponent<Animator>();
        hit = life;
        hpSlider.maxValue = life;
    }
    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Attack")
        {
            if (--hit <= 0)
            { 
            anim.Play(destroyState);
            //Destruir hpSlider
            hpSlider.gameObject.SetActive(false);
                yield return new WaitForSeconds(timeForDisable);
            foreach
                (Collider2D collider in GetComponents<Collider2D>())
                { 
                collider.enabled = false;
                }
            }    
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hit;

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
