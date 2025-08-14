using UnityEngine;

public class Drag : MonoBehaviour
{
    private Collider2D col;

    private Vector3 startDragPos;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPos = transform.position;
        transform.position = GetMousePositionInWorld();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorld();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out CardArea cardArea))
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
}
