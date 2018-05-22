using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LibraryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void backToMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void characterLibrary(){
		SceneManager.LoadScene ("CharacterLibrary");
	}
	public void monsterLibrary(){
		SceneManager.LoadScene ("MonsterLibrary");
	}
	public void learnMoreLibrary(){
		SceneManager.LoadScene ("LearnMoreLibrary");
	}
}
