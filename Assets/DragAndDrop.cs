using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(1000, 0, 0));
    }

    void Update()
    {
        
    }

    void OnMouseDown ()
    {

    }

    void OnCollisionEnter2D ()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // rb.Active = false;
        rb.velocity = Vector3.zero;
        // rb.angularVelocity = Vector3.zero;
        Debug.Log("collision entered!");

    }
}
