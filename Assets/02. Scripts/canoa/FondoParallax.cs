using UnityEngine;
using UnityEngine.UI;

public class FondoParallax : MonoBehaviour
{
    public float parallaxspeed = 0.2f;
    public RawImage fondo; 

    void Update()
    {   
    Parallax();   
    }
    void Parallax()
    {
        float finalspeed = parallaxspeed * Time.deltaTime;
        fondo.uvRect = new Rect(fondo.uvRect.x + finalspeed, 0f, 1f, 1f);
    }
   
}
