using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   // can be referenced and adjusted in inspector window
   public float thrustForce = 1f;
   Rigidbody2D rb;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            Vector2 direction = mousePos - transform.position;

            transform.up = direction;

            rb.AddForce(direction * thrustForce);

            Debug.Log("Mouse position: " + mousePos);
        }
    }
}
