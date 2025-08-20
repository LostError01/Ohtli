using UnityEngine;
using UnityEngine.UI;
public class tiempo : MonoBehaviour
{
    public Text contador;
    public int minutos;
    public float segundos;
    public float segundoslimite;
    public Color rojo;
    void Start()
    {
        letreto();
    }

    // Update is called once per frame
    void Update()
    {
        segundos -= Time.deltaTime;
        if(segundos <= 0 ) {
            if( minutos ==0 ) {
                return;
                 }
            else {
                segundos = 59;
            minutos -= 1;
                 }
        }   
        letreto(); 
        if(segundos < 0 &&  minutos < 1 ) {
            contador.color = rojo;
           }
    }
    public void letreto()
    {
        if( segundos < 9.5f) {
        contador.text = minutos.ToString() + ":0" + segundos.ToString("f0");
        }
        else {
            contador.text = minutos.ToString() + ":" + segundos.ToString("f0");
        }
    }
}
