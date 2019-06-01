using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ControlItem : MonoBehaviour {
    public float speed=10f;
	public float rotationSpeed=1f;
	
	private Rigidbody2D rigidbody;
	private Vector2 tempVector2;
	private Vector3 tempVector3;
    private float tempFloat;
	
	void Start(){
		rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
		tempVector3=transform.rotation.eulerAngles;
		tempVector3.z-=Input.GetAxisRaw("Horizontal")*rotationSpeed;
		transform.rotation= Quaternion.Euler(tempVector3);		
		tempVector2 = new Vector2(Input.GetAxisRaw("Vertical"), 0).normalized*speed;
		rigidbody.velocity=Rotate(tempVector2,tempVector3.z);
    }
	
	public Vector2 Rotate(Vector2 v, float degrees) {
         float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
         float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
         float tx = v.x;
         float ty = v.y;
         v.x = (cos * tx) - (sin * ty);
         v.y = (sin * tx) + (cos * ty);
         return v;
     }
}
