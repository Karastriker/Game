using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public Generate QuizManager;

    public void answer()
    {
        if(isCorrect)
        {
            Debug.Log("CorrectAnswer");
            QuizManager.correct();
        }
        else
        {
            Debug.Log("WrongAnswer");
            QuizManager.wrong();
        }
    }
}
