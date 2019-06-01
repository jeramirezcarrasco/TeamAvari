using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    public int LookSpeed;
    private LineOfSight lineofsight;
    private Shooting1 shooting1;
    int angle;
    bool left;

    // Use this for initialization
    void Awake ()
    {
        lineofsight = GetComponent<LineOfSight>();
        shooting1 = GetComponent<Shooting1>();

    }

    private void Start()
    {
        angle = 90;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lineofsight.Spoted())
        {
            lineofsight.CurrFov = lineofsight.Fov;
            LookPatrol();
            shooting1.endShooting();

        }
        else if(lineofsight.Spoted())
        {
            lineofsight.CurrFov = 110;
            shooting1.startShooting();
            shooting1.Point();
        }

    }

    void LookPatrol()
    {
        if (left)
        {
            if (angle < 10)
            {
                left = false;
            }
            angle -= 1;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, LookSpeed * Time.deltaTime);
        }
        else if (!left)
        {
            if (angle > 170)
            {
                left = true;
            }
            angle += 1;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, LookSpeed * Time.deltaTime);
        }
    }
}
