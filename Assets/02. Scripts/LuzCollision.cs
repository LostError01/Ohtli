using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LuzCollision : MonoBehaviour
{
    //Quitar el shadow caster 2d al hacer trigger con Luz
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            ShadowCaster2D shadowCaster = GetComponentInParent<ShadowCaster2D>();
            if (shadowCaster != null)
            {
                shadowCaster.enabled = false;
            }
        }
    }

    //Activar el shadow caster 2d 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            ShadowCaster2D shadowCaster = GetComponentInParent<ShadowCaster2D>();
            if (shadowCaster != null)
            {
                shadowCaster.enabled = true;
            }
        }
    }
}
