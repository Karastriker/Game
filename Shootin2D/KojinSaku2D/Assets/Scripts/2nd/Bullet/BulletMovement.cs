using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed, 0, 0);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.manager.UpdateScore(100);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}
