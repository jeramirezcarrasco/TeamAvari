using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {

	private static KeyboardInput instance;
    public static KeyboardInput Instance{
        get{
            return instance;
        }
    }

	public delegate void UpPressedDelegate();
    public event UpPressedDelegate UpPressed;

	public delegate void UpReleasedDelegate();
    public event UpReleasedDelegate UpReleased;

	public delegate void LeftPressedDelegate();
    public event LeftPressedDelegate LeftPressed;

	public delegate void LeftReleasedDelegate();
    public event LeftReleasedDelegate LeftReleased;

	public delegate void RightPressedDelegate();
    public event RightPressedDelegate RightPressed;

	public delegate void RightReleasedDelegate();
    public event RightReleasedDelegate RightReleased;

	public delegate void DownPressedDelegate();
    public event DownPressedDelegate DownPressed;

	public delegate void DownReleasedDelegate();
    public event DownReleasedDelegate DownReleased;
	
	public delegate void FlyPressedDelegate();
    public event FlyPressedDelegate FlyPressed;
	
	public delegate void FlyReleasedDelegate();
    public event FlyReleasedDelegate FlyReleased;

	public KeyCode upKeycode;
	public KeyCode leftKeycode;
	public KeyCode rightKeycode;
	public KeyCode downKeycode;
	public KeyCode flyKeycode;
	
	void Awake () {
		instance=this;
	}
	
	void Update () {
		if(Input.GetKeyDown(upKeycode)){
			if(UpPressed!=null){				
				UpPressed();
			}
		}
		if(Input.GetKeyUp(upKeycode)){
			if(UpReleased!=null){
				UpReleased();
			}
		}
		if(Input.GetKeyDown(leftKeycode)){
			if(LeftPressed!=null){
				LeftPressed();
			}
		}
		if(Input.GetKeyUp(leftKeycode)){
			if(LeftReleased!=null){
				LeftReleased();
			}
		}
		if(Input.GetKeyDown(rightKeycode)){
			if(RightPressed!=null){
				RightPressed();
			}
		}
		if(Input.GetKeyUp(rightKeycode)){
			if(RightReleased!=null){
				RightReleased();
			}
		}
		if(Input.GetKeyDown(downKeycode)){
			if(DownPressed!=null){
				DownPressed();
			}
		}
		if(Input.GetKeyUp(downKeycode)){
			if(DownReleased!=null){
				DownReleased();
			}
		}
		if(Input.GetKeyDown(flyKeycode)){
			if(FlyPressed!=null){
				FlyPressed();
			}
		}
		if(Input.GetKeyUp(flyKeycode)){
			if(FlyReleased!=null){
				FlyReleased();
			}
		}
	}
}
