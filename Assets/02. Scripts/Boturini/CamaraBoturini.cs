using UnityEngine;

public class CamaraBoturini : MonoBehaviour
{
    public GameObject Follow; 
    private Vector3 target; 
    public float MoveSpeed; 

    void Update()
    {
        target = new Vector3(Follow.transform.position.x,
       Follow.transform.position.y, transform.position.z);
        transform.position =
        Vector3.Lerp(transform.position,
        target, MoveSpeed * Time.deltaTime);
       
    }
}
