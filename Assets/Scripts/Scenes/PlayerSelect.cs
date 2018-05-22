using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerSelect : MonoBehaviour {
	private int countPlayer;
	// Use this for initialization
	void Start () {
		countPlayer = 0;
		ApplicationController.player1 = new PlayerBehaviour ();
		ApplicationController.player2 = new PlayerBehaviour ();
		ApplicationController.player3 = new PlayerBehaviour ();
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

	public void SelectPlayer(Text name){
		Debug.Log (name.text);
		if (countPlayer < 3) {
			countPlayer++;
			switch(countPlayer){
			case 1:
				ApplicationController.player1.namePlayer = name.text;
				Debug.Log (ApplicationController.player1.namePlayer);
				break;
			case 2:
				ApplicationController.player2.namePlayer = name.text;
				Debug.Log (ApplicationController.player1.namePlayer);
				Debug.Log (ApplicationController.player2.namePlayer);
				break;
			case 3:
				ApplicationController.player3.namePlayer = name.text;
				Debug.Log (ApplicationController.player1.namePlayer);
				Debug.Log (ApplicationController.player2.namePlayer);
				Debug.Log (ApplicationController.player3.namePlayer);
				break;
			}
		} else {
			ApplicationController.player1.namePlayer = ApplicationController.player2.namePlayer;
			ApplicationController.player2.namePlayer = ApplicationController.player3.namePlayer;
			ApplicationController.player3.namePlayer = name.text;
			Debug.Log (ApplicationController.player1.namePlayer);
			Debug.Log (ApplicationController.player2.namePlayer);
			Debug.Log (ApplicationController.player3.namePlayer);
		}
	}
}
