using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class CharBase : MonoBehaviour {
	public int totalLife;
	private int currentLife;
	public int totalMana;
	private int currentMana;
	public List<AttackBase> attacks;

	//ui
	public Slider lifeSlider;
	public Slider manaSlider;

	// Use this for initialization
	protected void Start () {
		currentLife = totalLife;
		currentMana = totalMana;
		lifeSlider.maxValue = totalLife;
		lifeSlider.value = currentLife;
		manaSlider.maxValue = totalMana;
		manaSlider.value = currentMana;
	}
	
	// Update is called once per frame
	void Update () {
		//lifeSlider.value = currentLife;
		//manaSlider.value = currentMana;
	}
	public bool haveMana(int manaCoust){
		if (currentMana >= manaCoust) {
			currentMana -= manaCoust;
			return true;
		}
		return false;
	}
	public void ApplyDamage(int damage){
		currentLife -= damage;
		if (currentLife <= 0) {
			charDie ();
		}
	}
	private void charDie(){
		onDie ();
	}
	protected abstract void onDie();
}
