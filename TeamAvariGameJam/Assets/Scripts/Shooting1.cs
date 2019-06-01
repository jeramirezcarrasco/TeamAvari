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
    public float GunAimSpeed;
    public float attackspeedSeconds;
    public GameObject Gun;
    public GameObject Bullelt;
    public float Spread;
    private bool GunOn;
    public float WaitAwaketime;
    public float BulletGap;
    public float BulletSpeedGap;
    private bool bussy;


    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        GunOn = false;
        
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
    
    public void startShooting()
    {
        if (!GunOn && !bussy)
        {
            GunOn = true;
            StartCoroutine(BulletSpawn());
        }
    }

    public void endShooting()
    {
        GunOn = false;
    }

    void Shoot()
    {
        if (GunOn)
        {
            GameObject bullet = (GameObject)Instantiate(Bullelt, Gun.transform.position, Gun.transform.rotation);
            BulletMove BulletSpeed = bullet.GetComponent<BulletMove>();
            BulletSpeed.speed = BulletSpeed.speed - Random.Range(-BulletSpeedGap, 0);
            bullet.transform.Rotate(0, 0, Random.Range(-Spread, Spread));
        }

    }

    public void Point()
    {
        Vector2 direction = Player.position - Gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Gun.transform.rotation = Quaternion.Slerp(Gun.transform.rotation, rotation, GunAimSpeed * Time.deltaTime);
    }

    IEnumerator BulletSpawn()
    {
        yield return new WaitForSeconds(WaitAwaketime);
        while (GunOn)
        {
            
            Shoot();
            bussy = true;
            float gap = attackspeedSeconds + Random.Range(0, BulletGap);
            yield return new WaitForSeconds(gap);
            bussy = false;
        }

    }

}
