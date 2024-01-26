using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularShot : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float fireRate = 0.5f; // Time between shots
    public int bulletsPerVolley = 36; // Number of bullets to shoot in each volley
    public float bulletSpeed = 1.0f; // Speed of the bullets
    public float speed = 0.02f;

    private float fireTimer;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            FireBullets();
            fireTimer = fireRate;
        }
    }

    void FireBullets()
    {
        float angleStep = 360f / bulletsPerVolley;

        for (int i = 0; i < bulletsPerVolley; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDir = Quaternion.Euler(0, 0, angle) * Vector3.right;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = bulletDir * bulletSpeed;
            }
            else
            {
                Debug.LogError("Rigidbody2D not found on the bullet prefab.");
            }
        }
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
