using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    public GameObject pipePrefab;   
    public GameObject Generador;
    private int generadortime = 100;
    private int timer;

    void FixedUpdate()
    {
        timer++;
        if (timer >= generadortime)
        {
            timer = 0;
            generadortime = Random.Range(50, 100);
            GameObject newObstacle =
            Instantiate(pipePrefab, new Vector2
            (Generador.transform.position.x,
            Generador.transform.position.y
            + Random.Range(-9.5f, 0.5f)), Generador.transform.rotation);
            Destroy(newObstacle, 5f);
        }
    }
}
