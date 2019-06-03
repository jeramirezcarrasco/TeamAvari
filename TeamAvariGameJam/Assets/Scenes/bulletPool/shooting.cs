using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    [SerializeField] private Transform shootPos;
    objectPooler objectPool;

    [SerializeField] private float startTimeBtwShot;
    [SerializeField] private float timeBtwShot;
    public Transform Player;
    public float speed;
    public float attackspeed;


    private void Awake()
    {
        objectPool = objectPooler.Instance;
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //if(timeBtwShot < 0.2)
        //{
        //    objectPooler.SpawnFromPool("Bullets", shootPos.position, transform.rotation);
        //    timeBtwShot = startTimeBtwShot;
        //}
        //else
        //{
        //    timeBtwShot -= Time.deltaTime;
        //}
        Point();

    }

    private void Point()
    {
        Vector2 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

}
