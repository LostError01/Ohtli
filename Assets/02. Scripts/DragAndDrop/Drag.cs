using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Drag : MonoBehaviour
{
    private Collider2D col;

    private Vector3 startDragPos;

    private string[] namesDrag = { "Patch01", "Patch02", "Patch03", "Patch04" };
    private string[] namesDrop = { "Scratch01", "Scratch02", "Scratch03", "Scratch04" };

    [Header("Numero de Parche (Va del 0 al 3)")]
    [SerializeField] private int indexObject;

    [Header("Aviso por si se quiere hacer drag con luz encendida")]
    private string avisoLuzEncendida = "No puedes mover los parches con la luz encendida";
    [SerializeField] private TextMeshProUGUI avisoText;
    [SerializeField] private Animator avisoAnim;

    private void Start()
    {
        col = this.GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPos = transform.position;
        transform.position = GetMousePositionInWorld();
    }

    private void OnMouseDrag()
    {
        if(!ScratchReveal.luzEncendida)
        transform.position = GetMousePositionInWorld();
        else
        {
            avisoAnim.SetBool("Start",true);
            avisoText.text = avisoLuzEncendida;
            StartCoroutine(StartAnimAfterDelay(3f));
        }
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;

        if (hitCollider != null && hitCollider.CompareTag(namesDrop[indexObject]) && this.CompareTag(namesDrag[indexObject]) && hitCollider.TryGetComponent(out CardArea cardArea))
        {
            cardArea.OnCardDrop(this);
        }
        else
        {
            transform.position = startDragPos;
        }
    }

    public Vector3 GetMousePositionInWorld()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        return pos;
    }

    //Método para terminar la animación de aviso despues de 2 segundos
    private IEnumerator StartAnimAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        avisoAnim.SetBool("Start", false);
    }
}
