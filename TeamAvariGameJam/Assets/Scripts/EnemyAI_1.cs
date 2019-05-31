﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1 : MonoBehaviour
{

    public float Maxspeed;
    public float DownView;
    float Speed;
    public float Acceleration;

    private bool MovRight = true;

    public Transform GroundDetection1;
    public Transform GroundDetection2;
    private LineOfSight lineofsight;

    private void Awake()
    {
        lineofsight = GetComponent<LineOfSight>();
    }

    private void Start()
    {

        float Speed = Maxspeed;
    }
    void Update()
    {
        if (!lineofsight.Spoted())
        {
            Patrol();
        }
            
    }

    void Patrol()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        RaycastHit2D groundSlowDown = Physics2D.Raycast(GroundDetection2.position, Vector2.down, DownView);
        RaycastHit2D ground = Physics2D.Raycast(GroundDetection1.position, Vector2.down, DownView);
        if (groundSlowDown.collider == false)
        {
            if (Speed > (Maxspeed/3))
            {
                Speed -= Acceleration;
            }
        }
        else
        {
            if (Speed < Maxspeed)
            {
                Speed += Acceleration;
            }
        }
        if (ground.collider == false)
        {
            if (MovRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovRight = false;
                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovRight = true;

            }

        }
    }

   
}

    
