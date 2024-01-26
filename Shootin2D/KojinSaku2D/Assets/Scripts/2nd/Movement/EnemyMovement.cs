using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bulletPref;
    public Transform bulletPos;
    private float timer = 0f;
    //public float bulletForce = 10f;

    private float moveSpeed = 2.00f;
    public float moveDistance;
    private Vector2 startPosition;

    public float fireRate = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer)
        {
            timer = Time.time + 1f / fireRate;
            shoot();
        }

        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        float newX = transform.position.x - 1.5f * Time.deltaTime; 
        transform.position = new Vector2(newX, newY);

    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPref, bulletPos.position, bulletPos.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(bulletPos.right * bulletForce, ForceMode2D.Impulse);
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}
