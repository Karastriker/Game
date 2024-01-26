using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class TrueOrFalse : MonoBehaviour
{
    public Questions[] questions;
    private static List<Questions> NewQuestions;
    private Questions currentQuestion;
    [SerializeField]
    private Text QuestionText;
    [SerializeField]
    private GameObject trueAnswer;
    [SerializeField]
    private GameObject falseAnswer;

    public Countdown timer;

    int totalQuestion = 0;
    public int score;

    void Start()
    {
        if (NewQuestions == null || NewQuestions.Count == 0)
        {
            NewQuestions = questions.ToList<Questions>();
        }
        totalQuestion = NewQuestions.Count;
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, NewQuestions.Count);
        currentQuestion = NewQuestions[randomQuestionIndex];
        QuestionText.text = currentQuestion.question;
        NewQuestions.RemoveAt(randomQuestionIndex);
    }

    public void Correct()
    {
        timer.TimeLeft = 10;
        score += 1;
        Debug.Log("CORRECT");
        if (score >= totalQuestion)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SetCurrentQuestion();
        } 
    }

    public void Wrong()
    {
        timer.TimeLeft = 10;
        Debug.Log("WRONG");
        if (score <= totalQuestion)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
