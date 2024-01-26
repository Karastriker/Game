using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generate : MonoBehaviour
{
    public List<QnA> Sentences;
    public int CurrentQuestion;
    public GameObject[] options;
    public Text QuestionTxT;
    public Countdown timer;

    public Image currentQ;
    public List<Transform> nbQuestion;


    int totalQuestion = 0;
    public int score;


    public void Start()
    {
        totalQuestion = Sentences.Count;
        currentQ.transform.position = nbQuestion[CurrentQuestion].position;
        generateQuestion();

    }

    public void correct()
    {
        score += 1;
        Sentences.RemoveAt(CurrentQuestion);
        timer.TimeLeft = 10;
        generateQuestion();
    }

    public void wrong()
    {
        Sentences.RemoveAt(CurrentQuestion);
        timer.TimeLeft = 10;
        generateQuestion();
    }

    public void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = 
                Sentences[CurrentQuestion].Answers[i];
            if(Sentences[CurrentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if(Sentences.Count > 0)
        {
            StartCoroutine(WinQ());
            CurrentQuestion = Random.Range(0, Sentences.Count);
            QuestionTxT.text = Sentences[CurrentQuestion].Question;
            SetAnswer();
        }
        else
        {
            SceneManager.LoadScene(1);
            Debug.Log("Out of Question");
        }
    }

    IEnumerator WinQ()
    {
        yield return new WaitForSeconds(0.02f);
        currentQ.transform.position = nbQuestion[CurrentQuestion].position;
    }
}
