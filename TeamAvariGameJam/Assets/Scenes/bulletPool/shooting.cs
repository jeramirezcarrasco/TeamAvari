using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField] private Transform shootPos;
    ObjectPooler objectPooler;

    [SerializeField] private float startTimeBtwShot;
    [SerializeField] private float timeBtwShot;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if(timeBtwShot < 0.2)
        {
            objectPooler.SpawnFromPool("Bullets", shootPos.position, transform.rotation);
            timeBtwShot = startTimeBtwShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }

    }
}
