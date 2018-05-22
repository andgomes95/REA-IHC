using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour {
	private static int currentLevel;

	public static void SetLevel(int level){
		currentLevel = level;
	}

}
