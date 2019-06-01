using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PidgeonMovement : MonoBehaviour {
	
	private Rigidbody2D rigidbody;
	
	public float flyingForce;
	public float walkingSpeed;
	public float flyingSpeed;
	public float maxVerticalSpeed;
	
	public int maximumFlaps=10;
	private int currentFlapsRemaining;
	
	private Vector2 tempVector;
	private bool isGrounded;
	private bool canFlap;
	
	private static PidgeonMovement instance;
    public static PidgeonMovement Instance{
        get{
            return instance;
        }
    }
	
	void Awake(){
		instance=this;
		currentFlapsRemaining=maximumFlaps;		
	}
	
	private void Start() {
		rigidbody=GetComponent<Rigidbody2D>();
		currentFlapsRemaining=maximumFlaps;
	}
	
	public void Flap(){
		if(currentFlapsRemaining>0){
			tempVector.x=0;
			tempVector.y=flyingForce;
			Debug.Log(rigidbody.velocity);
			if((rigidbody.velocity.y)<maxVerticalSpeed){
				rigidbody.AddForce(tempVector);
			}
			currentFlapsRemaining--;
			isGrounded=false;
		}
	}
	
	public void InGround(){
		isGrounded=true;
		currentFlapsRemaining=maximumFlaps;
	}
	
	public void MoveSide(float y){		
		if(isGrounded){
			tempVector.x=walkingSpeed*y;
		}else{
			tempVector.x=walkingSpeed*y;			
		}
		tempVector.y=rigidbody.velocity.y;
		rigidbody.velocity=tempVector;
	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Ground"){
			InGround();
        }
	}
	
	/* Do something about this later! */
	
	private void FixedUpdate() {
		float y = Input.GetAxisRaw("Horizontal");
		MoveSide(y);
	}
}
