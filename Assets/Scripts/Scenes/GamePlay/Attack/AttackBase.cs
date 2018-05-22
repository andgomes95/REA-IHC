using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeAttack{
	NORMAL,
	FIRE,
	WATER,
	EARTH,
	WIND,
	LIGHT,
	DARK
}
public abstract class AttackBase : MonoBehaviour {

	public int damageAttack;
	public TypeAttack typeAttack;
	public string nameAttack;
	public Sprite iconAttack;
	public int manaAttack;

	public void hit(CharBase target, CharBase user){
		if(user.haveMana(manaAttack)) {
			target.ApplyDamage (damageAttack);
			onHit ();
		}
	}
	protected abstract void onHit ();
}
