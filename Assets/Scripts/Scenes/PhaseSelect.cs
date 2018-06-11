using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseSelect : MonoBehaviour {
	public GameObject buttonPhase02;
	// Use this for initialization
	void Start () {
		if (ApplicationController.getLevelPossible () < 1) {
			buttonPhase02.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BackPlayerSelect(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void goLibrary(){
		SceneManager.LoadScene ("Library");
	}
	public void SelectPhase(int level){
		ApplicationController.SetLevel (level);
		if(level == 1){
			SceneManager.LoadScene ("Phase01");
		}else if(level == 2 && ApplicationController.getLevelPossible() > 0){
			SceneManager.LoadScene ("Phase02");
		}
	}
}
