using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;


    public int tipo = -1;
    private Animator _animator;
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
        Instantiate(prefabs[tipo], transform.position, transform.rotation,transform);
        Revelar();
    }

    void Update()
    {
        
    }
    public void Revelar()
    {
        _animator.SetBool(name: "revelar", value: true);
    }

    public void esconder()
    {
        _animator.SetBool(name:"revelar", value: false);
    }
}
