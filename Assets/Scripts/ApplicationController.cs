using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour {
	private static int currentLevel;
	public static PlayerBehaviour player1;
	public static PlayerBehaviour player2;
	public static PlayerBehaviour player3;
	//public List<PlayerBehaviour> players;
	public static void SetLevel(int level){
		currentLevel = level;
	}
	public static int GetLevel(){
		return currentLevel;
	}
}
