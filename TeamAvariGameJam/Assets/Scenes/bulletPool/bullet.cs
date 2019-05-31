using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float speed;
    [SerializeField] private float offset;

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

}
