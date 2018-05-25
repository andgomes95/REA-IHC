using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharBase {



	// Use this for initialization
	void Start () {
		base.Start ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	protected override void onDie ()
	{

		throw new System.NotImplementedException ();
	}

}
