using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int cube;
    public GameObject Score;

    void Update()
    {
        Score.GetComponent<Text>().text = "Count: " + cube;
    }
}
