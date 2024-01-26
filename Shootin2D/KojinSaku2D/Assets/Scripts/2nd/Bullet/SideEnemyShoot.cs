using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEnemyShoot : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bulletPref;
    public Transform bulletPos;
    private float timer = 0f;


    public float fireRate = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPref, bulletPos.position, bulletPos.rotation);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}
