using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointing : MonoBehaviour
{

    public float speed = 5f;

    void Update()
    {
        //var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }


}
