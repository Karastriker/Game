using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            GameManager.manager.UpdateScore(100);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
