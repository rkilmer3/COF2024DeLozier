using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text mathProblem, answer1, answer2, answer3, answer4; //UI Elements
    public bool solvedProblem = false; //Decides whether or not the problem is solved
    public GameObject square; //Doorway object in the scene
    private int x, y; //Operation numbers
    private int operationNumber; //Operation to be performed
    private char operationChar; //Char representation of operation
    private int correctAnswer; //Holds correct answer. See build usages for how this variable is used.
    public int answerInsert; //Variable to hold which UI element holds the correct answer.

    // Start is called before the first frame update
    void Start()
    {
        problemSet(); //Set the problem
        problemDisplay(); //Display the problem
    }

    // Update is called once per frame
    void Update()
    {
        if (solvedProblem)
        {
            clearProblem(); //Clear the problem values
            square.SetActive(false); //Open the doorway
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
        Debug.Log(operationNumber);
        if(operationNumber == 1)
        {
            operationChar = '+';
        }
        else if (operationNumber == 2)
        {
            operationChar = '-';
        }    
    }

    public void clearProblem()
    {
        mathProblem.text = "Move on!";
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
    }

    public void problemDisplay()
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
            answer1.text = correctAnswer.ToString();
            answer2.text = Random.Range(0, 21).ToString();
            answer3.text = Random.Range(0, 21).ToString();
            answer4.text = Random.Range(0, 21).ToString();
        }
        else if(answerInsert == 2)
        {
            answer2.text = correctAnswer.ToString();
            answer1.text = Random.Range(0, 21).ToString();
            answer3.text = Random.Range(0, 21).ToString();
            answer4.text = Random.Range(0, 21).ToString();
        }
        else if (answerInsert == 3)
        {
            answer3.text = correctAnswer.ToString();
            answer2.text = Random.Range(0, 21).ToString();
            answer1.text = Random.Range(0, 21).ToString();
            answer4.text = Random.Range(0, 21).ToString();
        }
        else if (answerInsert == 4)
        {
            answer4.text = correctAnswer.ToString();
            answer2.text = Random.Range(0, 21).ToString();
            answer3.text = Random.Range(0, 21).ToString();
            answer1.text = Random.Range(0, 21).ToString();
        }
    }

    private List<int> uniqueAnswers(int correctAnswer)
    {
        List<int> answers = new List<int>();
        answers.Add(correctAnswer);
        
        while (answers.count < 4)
        {
            int randomAnswer = Random.Range(0, 21);
            if (!answers.Constains(randomAnswer))
            {
                answers.Add(randomAnswer);
            }
        }

        return answers;
    
    }



}
