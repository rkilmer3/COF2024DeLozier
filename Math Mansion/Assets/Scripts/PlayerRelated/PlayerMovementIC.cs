using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementIC : MonoBehaviour
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
            if (gameManager.GetComponent<GameManagerIndividual>().answerInsert == 1)
            {
                gameManager.GetComponent<GameManagerIndividual>().solvedProblem = true;
            }
            else
            {
                gameManager.GetComponent<GameManagerIndividual>().tryAgainDisplay(1);
            }
        }

        if (other.CompareTag("Answer 2"))
        {
            if (gameManager.GetComponent<GameManagerIndividual>().answerInsert == 2)
            {
                gameManager.GetComponent<GameManagerIndividual>().solvedProblem = true;
            }
            else
            {
                gameManager.GetComponent<GameManagerIndividual>().tryAgainDisplay(2);
            }
        }

        if (other.CompareTag("Answer 3"))
        {
            if (gameManager.GetComponent<GameManagerIndividual>().answerInsert == 3)
            {
                gameManager.GetComponent<GameManagerIndividual>().solvedProblem = true;
            }
            else
            {
                gameManager.GetComponent<GameManagerIndividual>().tryAgainDisplay(3);
            }
        }

        if (other.CompareTag("Answer 4"))
        {
            if (gameManager.GetComponent<GameManagerIndividual>().answerInsert == 4)
            {
                gameManager.GetComponent<GameManagerIndividual>().solvedProblem = true;
            }
            else
            {
                gameManager.GetComponent<GameManagerIndividual>().tryAgainDisplay(4);
            }
        }

        if (other.CompareTag("Level 2 Trigger"))
        {
            gameManager.GetComponent<GameManagerIndividual>().directToLevel(2);
        }

        if (other.CompareTag("Level 3 Trigger"))
        {
            gameManager.GetComponent<GameManagerIndividual>().directToLevel(3);
        }

        if (other.CompareTag("Level 4 Trigger"))
        {
            gameManager.GetComponent<GameManagerIndividual>().directToLevel(4);
        }

        if (other.CompareTag("Level 5 Trigger"))
        {
            gameManager.GetComponent<GameManagerIndividual>().directToLevel(5);
        }

        if (other.CompareTag("End Screen Trigger"))
        {
            gameManager.GetComponent<GameManagerIndividual>().directToLevel(6);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}
