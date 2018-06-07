using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
		SceneManager.LoadScene ("Phase01");
	}
}
