using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ControlItem : MonoBehaviour {
    public float speed;
	public float rotationSpeed;
	private Rigidbody2D rigidbody;
	private Vector2 tempVector2;
	private Vector3 tempVector3;
    void Start(){
		rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        tempVector2 = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized*speed;
		rigidbody.velocity=tempVector2;
		tempVector3=transform.rotation.eulerAngles;
		tempVector3.z+=Input.GetAxisRaw("Vertical")*rotationSpeed;
    }
}
