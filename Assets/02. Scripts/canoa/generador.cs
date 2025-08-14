using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> pipePrefab;
    private int tipo = -1;
    public GameObject Generador;
    private int generadortime = 100;
    private int timer;

    void FixedUpdate()
    {
        timer++;
        if (timer >= generadortime)
        {
            timer = 0;
            generadortime = Random.Range(50, 90);
            tipo = UnityEngine.Random.Range(0, pipePrefab.Count);
            GameObject newObstacle =
            Instantiate(pipePrefab[tipo], new Vector2
            (Generador.transform.position.x-5,
            Generador.transform.position.y
            + Random.Range(-1.5f, .5f)), Generador.transform.rotation);
            Destroy(newObstacle, 5f);
        }
    }
}
