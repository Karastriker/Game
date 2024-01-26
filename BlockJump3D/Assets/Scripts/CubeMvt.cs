using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMvt : MonoBehaviour
{
    Rigidbody rb;
    public bool showClear;
    public GameManager gameManager;
    //public GameObject ClearScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;

        mouseDir = mouseDir.normalized;

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;

            this.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);

            direction.Normalize();

            this.GetComponent<Rigidbody>().AddForce(direction * 10, ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (GetComponent<MeshRenderer>().material.color == Color.red)
        {
            if (col.gameObject.CompareTag("BlueWall"))
            {
                Time.timeScale = 0;
                showClear = true;
                //ClearScreen.SetActive(true);
                gameManager.gameOver();
                Destroy(gameObject);
            }
        }

        else if (GetComponent<MeshRenderer>().material.color == Color.blue)
        {
            if (col.gameObject.CompareTag("RedWall"))
            {
                Time.timeScale = 0;
                showClear = true;
                //ClearScreen.SetActive(true);
                gameManager.gameOver();
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "RedBall")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

        else if (col.gameObject.CompareTag("BlueWall"))
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        if (col.gameObject.tag == "Goal")
        {
            Time.timeScale = 0;
            showClear = true;
            gameManager.gameClear();
        }
        else
        {
            showClear = false;
            //ClearScreen.SetActive(false);
        }
    }
}
