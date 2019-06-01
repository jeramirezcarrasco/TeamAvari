using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float speed;
    [SerializeField] private float offset;

    public Rigidbody2D rb;
    public GameObject Impact;
    private void OnEnable()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    

    private void Update()
    {
        if (playerPos != null && gameObject.activeSelf == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //you may need to change the vector2.____ part depending on which way the bullet is facing.
        }
    }

    void Start()
    {
        rb.velocity = transform.right * speed;

        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage();
            Instantiate(Impact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        Enemy2 enemy2 = hitInfo.GetComponent<Enemy2>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage();
            Instantiate(Impact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "Bullet")
        {
            Instantiate(Impact, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}