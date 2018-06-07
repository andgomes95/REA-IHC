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
		else if (weak == "3x2")
			return 2;
		else if (weak == "4x3")
			return 3;
		else if (weak == "cos(x)")
			return 4;
		else if (weak == "-sen(x)")
			return 5;
		else if (weak == "-cos(x)")
			return 6;
		else if (weak == "sen(x)")
			return 7;
		return 0;
	}
	public static string intToWeak(int num){
		if (num == 0)
			return "Const";
		else if (num == 1)
			return "2x";
		else if (num == 2)
			return "3x2";
		else if (num == 3)
			return "4x3";
		else if (num == 4)
			return "cos(x)";
		else if (num == 5)
			return "-sen(x)";
		else if (num == 6)
			return "-cos(x)";
		else if (num == 7)
			return "sen(x)";
		return "Const";
	}
	public static int attackToInt(string attack){
		if (attack == "x")
			return 0;
		else if (attack == "x2")
			return 1;
		else if (attack == "x3")
			return 2;
		else if (attack == "x4")
			return 3;
		else if (attack == "sen(x)")
			return 4;
		else if (attack == "cos(x)")
			return 5;
		else if (attack == "-sen(x)")
			return 6;
		else if (attack == "-cos(x)")
			return 7;
		return 0;
	}
}
