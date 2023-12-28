//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    bool gameCompleted;
    bool validInput;
    int number;
    int x;
    int score = 0;
    public TMP_InputField userInputFeild;
    public TextMeshProUGUI invalidMessage;
    public TextMeshProUGUI numberInfo;
    public TextMeshProUGUI scoreText;
    public Button restartBtn;
    // Start is called before the first frame update
    void Start()
    {
        invalidMessage.gameObject.SetActive(false);
        userInputFeild.onEndEdit.AddListener(OnEndEdit);
        numberInfo.gameObject.SetActive(false);
        number = Random.Range(0, 100);  
    }

    void OnEndEdit(string userInput)
    {
        if (int.TryParse(userInput, out x)) 
        {
            if(0>x || x > 100)
            {
                validInput = false;
                invalidMessage.gameObject.SetActive(true);
                numberInfo.gameObject.SetActive(false);
            }
            else
            {
                validInput = true;
                invalidMessage.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(true);
                if (!gameCompleted)
                {
                    numberInfo.gameObject.SetActive(true);
                    score++;
                    scoreText.text = "Score: " + score;
                    if (x < number)
                    {
                        numberInfo.text = x + " is lower than the number";
                    }
                    else if (x > number)
                    {
                        numberInfo.text = x + " is higher than the number";
                    }
                    else if (x == number)
                    {
                        gameCompleted = true;
                        numberInfo.text = "You Guessed the right number " + x;
                    }
                }
            }
        }
        else
        {
            validInput = false;
            invalidMessage.gameObject.SetActive(true);
            numberInfo.gameObject.SetActive(false);
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
