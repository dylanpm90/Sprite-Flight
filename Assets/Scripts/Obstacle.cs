using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // size vars for randomizer
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    
    // random speed vars to randomize
    public float minSpeed = 50f;
    public float maxSpeed = 150f;
    public float maxSpinSpeed = 10f;

    // declare var for rigidbody
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //make var for random size, speed and direction
        float randomSize = Random.Range(minSize, maxSize);
        // speed affects size
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        // random spin speed
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        // randomize direction
        Vector2 randomDirection = Random.insideUnitCircle;

        // get rigidbody component and apply transforms and forces
        rb = GetComponent<Rigidbody2D>();
        // randomize scale
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        // randomize torque speed
        rb.AddTorque(randomTorque);
        // make the rb move in a direction
        rb.AddForce(randomDirection * randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
