using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class PlaymakerTestJump : MonoBehaviour {

	public Vector3 rotations;
	public float jumpHeight=10f;
	private PlayMakerFSM[] playMakerFSMs;
	private PlayMakerFSM jumpFSM;
	
	public string FSMJumpName;
	public string jumpHeightName;
	
	private void Start() {
		playMakerFSMs = GetComponents<PlayMakerFSM>();
		for(int x=0;x<playMakerFSMs.Length;++x){			
			Debug.Log(playMakerFSMs[x].FsmName);
			if(playMakerFSMs[x].FsmName==FSMJumpName){
				jumpFSM=playMakerFSMs[x];
			}
		}
		jumpFSM.FsmVariables.GetFsmFloat(jumpHeightName).Value=jumpHeight;
	}
		
	public void RotateGO(){
		transform.Rotate(rotations);
	}
	
	private void Update() {
		if (Input.GetKeyDown(KeyCode.A)){
			if(jumpFSM.ActiveStateName=="Grounded"){
			jumpFSM.SetState("Jump");
			}
        }
	}
}
