using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting1 : MonoBehaviour
{

    [SerializeField] private Transform shootPos;
    ObjectPooler objectPooler;

    [SerializeField] private float startTimeBtwShot;
    [SerializeField] private float timeBtwShot;
    public Transform Player;
    public float speed;
    public float attackspeed;
    public GameObject Gun;
    public GameObject Bullelt;
    public float Spread;


    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
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

    }

    public void PointAndShot()
    {
        Point();
        Shoot();
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(Bullelt, Gun.transform.position, Gun.transform.rotation);
        bullet.transform.Rotate(0, 0, Random.Range(-Spread, Spread));
    }

    public void Point()
    {
        Vector2 direction = Player.position - Gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Gun.transform.rotation = Quaternion.Slerp(Gun.transform.rotation, rotation, speed * Time.deltaTime);
    }

}
