using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterLibraryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void backToLibraryMenu(){
		SceneManager.LoadScene ("Library");
	}
	public void goToOrcLibrary(){
		SceneManager.LoadScene("OrcLibrary");
	}
	public void goToOrcWALibrary(){
		SceneManager.LoadScene("OrcWALibrary");
	}
}
