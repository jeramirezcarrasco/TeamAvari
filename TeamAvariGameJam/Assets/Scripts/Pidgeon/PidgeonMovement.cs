using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PidgeonMovement : MonoBehaviour {
	
	private Rigidbody2D rigidbody;
	
	public float flyingForce=20f;
	public float walkingSpeed=5f;
	public float flyingSpeed=10f;
	public float maxVerticalSpeed=6f;
	
	public int maximumFlaps=10;
	private int currentFlapsRemaining;
	
	private Vector2 tempVector;
	private bool isGrounded;
	private bool canFlap;
	public SpriteRenderer spriteRendererPidgeon;

	public int maxLife=3;
	private int currentLife;
	
    //knockback variables
    [SerializeField] private float knockbackForce;
    [SerializeField] private float startTimeBtwKnock;
    private float timeBtwKnock;
    private int knockDir;

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
		currentLife=maxLife;
	}
	
	public void Flap(){
		if(currentFlapsRemaining>0){
			tempVector.x=0;
			tempVector.y=flyingForce;
			if((rigidbody.velocity.y)<maxVerticalSpeed){
				rigidbody.AddForce(tempVector);
			}
			currentFlapsRemaining--;
			isGrounded=false;
			if(UIManager.Instance!=null){
				UIManager.Instance.SetFlapsRemaining(currentFlapsRemaining);
			}
		}
	}
	
	public void InGround(){
		isGrounded=true;
		currentFlapsRemaining=maximumFlaps;
		if(UIManager.Instance!=null){
			UIManager.Instance.SetFlapsRemaining(currentFlapsRemaining);
		}
	}
	
	public void MoveSide(float y){
		if(y<0){
			spriteRendererPidgeon.flipX=true;
		}else{
			spriteRendererPidgeon.flipX=false;	
		}
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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(transform.position.x <= other.transform.position.x);
            if (transform.position.x <= other.transform.position.x)
            {
                knockDir = 1;
                timeBtwKnock = startTimeBtwKnock;
            }
            else
            {
                knockDir = -1;
                timeBtwKnock = startTimeBtwKnock;
            }
        }
    }

    /* Do something about this later! */

    private void FixedUpdate() {
		float y = Input.GetAxisRaw("Horizontal");
        if (timeBtwKnock < 0)        {
            MoveSide(y);
        }else{
            //rigidbody.velocity = new Vector2(-knockbackForce * knockDir, knockbackForce);
            rigidbody.AddForce(new Vector2(-knockbackForce * knockDir, knockbackForce));
            timeBtwKnock -= Time.deltaTime;           
        }
	}
	
	public void GetDamage(){
		
	}
}
