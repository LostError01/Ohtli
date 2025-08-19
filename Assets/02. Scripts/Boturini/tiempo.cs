using UnityEngine;
using UnityEngine.UI;
public class tiempo : MonoBehaviour
{
    public Text contador;
    public int minutos;
    public float segundos;
    void Start()
    {
        letreto();
    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime;
        if(segundos > 59 ) {
          segundos = 0;
            minutos -= 1;
        }   
        letreto(); 
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
