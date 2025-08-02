using UnityEngine;
using UnityEngine.UI;

public class FondoParallax : MonoBehaviour
{
    public float parallaxspeed = 0.2f;//velocidad mov
    public RawImage fondo; // public = visible en unity

    void Update()
    {   
    Parallax();   
    }
    void Parallax()
    {
        float finalspeed = parallaxspeed * Time.deltaTime;//0.2*60fps
        fondo.uvRect = new Rect(fondo.uvRect.x + finalspeed, 0f, 1f, 1f);//0.2
    }
   
}
