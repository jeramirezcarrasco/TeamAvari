using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PidgeonMovement : MonoBehaviour {
	
	private Rigidbody2D rigidbody;
	
	public float flyingForce;
	public float movingSpeed;
	
	public int maximumFlaps=10;
	public float timeBetweenFlapping;
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
			rigidbody.AddForce(tempVector);
			currentFlapsRemaining--;
			isGrounded=false;
		}
	}
	
	public void InGround(){
		isGrounded=true;
	}
	
	
}
