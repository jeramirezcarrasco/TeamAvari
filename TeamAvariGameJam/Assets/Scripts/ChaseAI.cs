using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour {

    Transform player;
    public int ChaseSpeed; 

    // Use this for initialization
    void Start ()
    {
        if(PidgeonMovement.Instance==null){
            player = GameObject.FindWithTag("Player").transform;
        }else{
            player=PidgeonMovement.Instance.transform;
        }
    }
	
	// Update is called once per frame

    public void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), ChaseSpeed * Time.deltaTime);
        if(player.position.x < transform.position.x)
            transform.eulerAngles = new Vector3(0, -180, 0);
        else if (player.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
