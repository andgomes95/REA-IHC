using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSelect : MonoBehaviour {
	private int countPlayer;
	// Use this for initialization
	void Start () {
		countPlayer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BackMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void Next(){
		if (countPlayer == 3) {
			SceneManager.LoadScene ("PhaseSelect");
		}
	}
	public void SelectPlayer(){
		countPlayer++;
		Debug.Log (countPlayer);
	}
}
