using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {
	public GameObject primaryButtons;
	public GameObject attackButtons;
	public GameObject enemyDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void tutorialAppearsPrimary(){
		primaryButtons.SetActive(true);
	}
	public void tutorialAppearsAttack(){
		primaryButtons.SetActive(false);
		attackButtons.SetActive(true);
	}
	public void tutorialNotAppears(){
		primaryButtons.SetActive(false);
		attackButtons.SetActive(false);
		enemyDamage.SetActive(false);
	}
	public void enemyDamageTutorial(){
		attackButtons.SetActive(false);	
		enemyDamage.SetActive(true);
	}
}
