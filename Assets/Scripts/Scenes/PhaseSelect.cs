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
		SceneManager.LoadScene ("PlayerSelect");
	}
	public void SelectPhase(int level){
		ApplicationController.SetLevel (level);
		SceneManager.LoadScene ("Phase01");
	}
}
