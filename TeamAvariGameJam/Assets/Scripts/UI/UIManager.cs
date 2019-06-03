using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject[] HealthBars;
	public GameObject[] FlapBars;

	public GameObject winScreen;
	public GameObject loseScreen;
	
	private static UIManager instance;
    public static UIManager Instance{
        get{
            return instance;
        }
    }

	void Awake(){
		instance=this;
	}
	
	private void Start() {
		winScreen.SetActive(false);
		loseScreen.SetActive(false);	
	}
	
	public void SetHealth(int value){
		for(int x=0;x<HealthBars.Length;++x){
			HealthBars[x].SetActive(false);
		}
		for(int x=0;x<value;++x){
			HealthBars[x].SetActive(true);
		}
	}
	
	public void SetFlapsRemaining(int value){
		for(int x=0;x<FlapBars.Length;++x){
			FlapBars[x].SetActive(false);
		}
		for(int x=0;x<value;++x){
			FlapBars[x].SetActive(true);
		}
	}
	
	public void SetWinScreen(){
		winScreen.SetActive(true);
	}
	
	public void SetLoseScreen(){
		loseScreen.SetActive(true);
	}
}
