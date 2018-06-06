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
	public static int weakToInt(string weak){
		if (weak == "Const")
			return 0;
		else if (weak == "2x")
			return 1;
		return 0;
	}
	public static string intToWeak(int num){
		if (num == 0)
			return "Const";
		else if (num == 1)
			return "2x";
		return "Const";
	}
	public static int attackToInt(string attack){
		if (attack == "x")
			return 0;
		else if (attack == "x^2")
			return 1;
		return 0;
	}
}
