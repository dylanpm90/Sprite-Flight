using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public UIDocument uiDocument;
    private Label scoreText;
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    [Tooltip("If enabled, the ship can be destroyed")]
    public bool canDestroy = true;
    public GameObject boosterFlame;
    Rigidbody2D rb;

    void Start()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateScore();
        MovePlayer();


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDestroy)
        {
            Destroy(gameObject);
        }
    }

    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);

        scoreText.text = "SCORE: " + score;
    }

    void MovePlayer()
    {
        // moves player if the mouse is pressed down in the 
        // direction of the cursor.
        if (Mouse.current.leftButton.isPressed)
        {
            // Calculate mouse direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;

            // Move player in direction of mouse
            transform.up = direction;
            rb.AddForce(direction * thrustForce);

            // Player will not go faster than maxSpeed when holding mouse.
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }

        }
        // flame booster appears if the mouse button is held.
        // disappears if released.
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }
    }

}