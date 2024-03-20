using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerSet : MonoBehaviour
{
    public TMP_Text mathProblem; //UI Elements
    public TMP_Text[] answer1, answer2, answer3, answer4; // Array of UI boxes
    public bool solvedProblem = false; //Decides whether or not the problem is solved
    private int x, y; //Operation numbers
    public GameObject camera; //Camera object to be set and unset as a player child
    public GameObject player; //Player object
    public GameObject[] doorways; //Array of the doorways
    public GameObject[] renewTrigger; //Array of the renew triggers to set a new problem
    private int operationNumber; //Operation to be performed
    private char operationChar; //Char representation of operation
    private int correctAnswer; //Holds correct answer. See build usages for how this variable is used.
    public int answerInsert; //Variable to hold which UI element holds the correct answer.

    // Start is called before the first frame update
    void Start()
    {
        problemSet(); //Set the problem
        problemDisplay(0); //Display the problem
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (solvedProblem)
        {
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            camera.transform.SetParent(player.transform);
        }
        else
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -10);
            camera.transform.SetParent(null);
        }
    }

    public void problemSet()
    {
        //This sets the problem for the equation
        //According to Ohio State 2nd Grade Math standards, students are required to add and subtract between 0 and 20
        //I'm going to assume this means that the operation cannot exceed 20, nor any of the numbers used in the equation
        //Basic gist for when you get to this Rosa, randomize first number between 0 and 10, repeat with second number.
        //Mod for operation. If subtraction, compare numbers and make the larger number the number we perform the operation on.
        x = Random.Range(0, 11);
        y = Random.Range(0, 11);
        operationNumber = Random.Range(1, 3);
        if(operationNumber == 1)
        {
            operationChar = '+';
        }
        else if (operationNumber == 2)
        {
            operationChar = '-';
        }    
    }

    public void clearProblem(int i)
    {
        mathProblem.text = "Move on!";
            answer1[i].text = "";
            answer2[i].text = "";
            answer3[i].text = "";
            answer4[i].text = "";
    }

    public void problemDisplay(int i)
    {
        if (operationChar == '+')
        {
            mathProblem.text = x.ToString() + operationChar + y.ToString();
            correctAnswer = x + y;
        }
        else if (operationChar == '-')
        {
            if (x > y)
            {
                mathProblem.text = x.ToString() + operationChar + y.ToString();
                correctAnswer = x - y;
            }
            else
            {
                mathProblem.text = y.ToString() + operationChar + x.ToString();
                correctAnswer = y - x;
            }
        }

        answerInsert = Random.Range(1, 4);
        if (answerInsert == 1)
        {
                answer1[i].text = correctAnswer.ToString();
                answer2[i].text = Random.Range(0, 21).ToString();
                answer3[i].text = Random.Range(0, 21).ToString();
                answer4[i].text = Random.Range(0, 21).ToString();
        }
        else if (answerInsert == 2)
        {

                answer2[i].text = correctAnswer.ToString();
                answer1[i].text = Random.Range(0, 21).ToString();
                answer3[i].text = Random.Range(0, 21).ToString();
                answer4[i].text = Random.Range(0, 21).ToString(); 

        }
        else if (answerInsert == 3)
        {

                answer3[i].text = correctAnswer.ToString();
                answer2[i].text = Random.Range(0, 21).ToString();
                answer1[i].text = Random.Range(0, 21).ToString();
                answer4[i].text = Random.Range(0, 21).ToString();

        }
        else if (answerInsert == 4)
        {
                answer4[i].text = correctAnswer.ToString();
                answer2[i].text = Random.Range(0, 21).ToString();
                answer3[i].text = Random.Range(0, 21).ToString();
                answer1[i].text = Random.Range(0, 21).ToString();
        }
    }

    public void Unlock(int door)
    {
         doorways[door].SetActive(false);
    }

    public void Lock(int door)
    {
        doorways[door].SetActive(true);
    }

     public void removeTrigger(int trigger)
     {
         renewTrigger[trigger].SetActive(false);
     }
}
