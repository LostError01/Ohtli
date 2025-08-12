using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class control : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    public int maxpares => prefabs.Count;
    public int tipo = -1;
    private Animator _animator;
    private Animator animator;
    public UnityEvent<control> OnClicked;

    private void Llamar()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (tipo < 0)
        {
            tipo = UnityEngine.Random.Range(0,prefabs.Count);
        }
        GameObject instancia = Instantiate(prefabs[tipo], transform.position, transform.rotation,transform);
        animator = instancia.GetComponent<Animator>();
    }

    private void OnMouseUpAsButton()
    {
        OnClicked.Invoke(this);
    }
    public void Revelar()
    {
        _animator.SetBool(name: "revelar", value: true);
        animator.SetBool(name: "visible", value: true);

    }

    public void esconder()
    {
        _animator.SetBool(name:"revelar", value: false);
        animator.SetBool(name: "visible", value: false);
    }
}
