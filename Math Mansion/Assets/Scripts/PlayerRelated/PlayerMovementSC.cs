using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSC : MonoBehaviour
{
    public Rigidbody2D rb; //Physics
    private float horizontal; //Horizontal input
    private float vertical; //Vertical input
    public float speed; //Player speed
    public GameObject gameManager; //To communicate with the main game manager

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Answer 1"))
        {
                gameManager.GetComponent<GameManagerSet>().solvedProblem = true;
        }

        if (other.CompareTag("Answer 2"))
        {
                gameManager.GetComponent<GameManagerSet>().solvedProblem = true;
        }

        if (other.CompareTag("Answer 3"))
        {
                gameManager.GetComponent<GameManagerSet>().solvedProblem = true;
        }

        if (other.CompareTag("Answer 4"))
        {
                gameManager.GetComponent<GameManagerSet>().solvedProblem = true;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}
