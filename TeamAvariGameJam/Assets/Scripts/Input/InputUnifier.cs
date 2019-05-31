using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUnifier : MonoBehaviour {
	
	public GameObject UIMobile;
	
	private static InputUnifier instance;
    public static InputUnifier Instance{
        get{
            return instance;
        }
    }
	
	void Awake(){
		instance=this;		
	}
	
	void Start () {
		SetUpControls();
	}
	
	public void SetUpControls(){
#if UNITY_ANDROID

#else

	KeyboardInput.Instance.UpPressed+=Up;
	KeyboardInput.Instance.UpReleased+=UpReleased;
	KeyboardInput.Instance.DownPressed+=Down;
	KeyboardInput.Instance.DownReleased+=DownReleased;
	KeyboardInput.Instance.LeftPressed+=Left;
	KeyboardInput.Instance.LeftReleased+=LeftReleased;
	KeyboardInput.Instance.RightPressed+=Right;
	KeyboardInput.Instance.RightReleased+=RightReleased;
	KeyboardInput.Instance.FlyPressed+=Fly;
	KeyboardInput.Instance.FlyReleased+=FlyReleased;
	
#endif	
	}
    
	public void Up(){
		//PlayerMovement.Instance.ChangeMovement(2,true);
    }    
	public void UpReleased(){	
		//PlayerMovement.Instance.ChangeMovement(2,false);	
	}
	
	public void Down(){
		//PlayerMovement.Instance.ChangeMovement(0,true);
    
	}
	public void DownReleased(){		
		//PlayerMovement.Instance.ChangeMovement(0,false);	
	}
	
	public void Left(){
		//PlayerMovement.Instance.ChangeMovement(1,true);    
	}
	public void LeftReleased(){		
		//PlayerMovement.Instance.ChangeMovement(1,false);	
	}
	
	public void Right(){
		//PlayerMovement.Instance.ChangeMovement(3,true);
	}
	public void RightReleased(){
    	//PlayerMovement.Instance.ChangeMovement(3,false);	
	}
	
	public void Fly(){
		PidgeonMovement.Instance.Flap();
	}
	public void FlyReleased(){
    	//PlayerMovement.Instance.ChangeMovement(3,false);	
	}
	
}
