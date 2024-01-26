using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            GameManager.manager.GameOver();
            Destroy(gameObject);
        }
        else if(col.gameObject.CompareTag("EnBullet"))
        {
            GameManager.manager.GameOver();
            Destroy(gameObject);
        }
    }
}
