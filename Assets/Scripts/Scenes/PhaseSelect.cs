using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseSelect : MonoBehaviour {
	public GameObject buttonPhase02;
	public GameObject buttonPhase03;
	public GameObject buttonPhase04;
	public GameObject buttonPhase05;
	// Use this for initialization
	void Start () {
		if (ApplicationController.getLevelPossible () < 1) {
			buttonPhase02.SetActive (false);
		}
		if (ApplicationController.getLevelPossible () < 2) {
			buttonPhase03.SetActive (false);
		}
		if (ApplicationController.getLevelPossible () < 3) {
			buttonPhase04.SetActive (false);
		}
		if (ApplicationController.getLevelPossible () < 4) {
			buttonPhase05.SetActive (false);
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
		if (level == 1) {
			SceneManager.LoadScene ("Phase01");
		} else if (level == 2 && ApplicationController.getLevelPossible () > 0) {
			SceneManager.LoadScene ("Phase02");
		} else if (level == 3 && ApplicationController.getLevelPossible () > 0) {
			SceneManager.LoadScene ("Phase03");
		} else if (level == 4 && ApplicationController.getLevelPossible () > 0) {
			SceneManager.LoadScene ("Phase04");
		} else if (level == 5 && ApplicationController.getLevelPossible () > 0) {
			SceneManager.LoadScene ("Phase05");
		}
	}
}
