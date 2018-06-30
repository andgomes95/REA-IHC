using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class CharBase : MonoBehaviour {
	public int totalLife;
	public string namePlayer;
	public int currentLife;
	public int totalMana;
	private int currentMana;
	public List<AttackBase> attacks;
	public int weakness;
	public Animator anime;

	//ui
	public Slider lifeSlider;
	public Slider manaSlider;
	public Image imageChar;
	public Image deadChar;

	// Use this for initialization
	protected void Start () {
		namePlayer = "";
		currentLife = totalLife;
		currentMana = totalMana;
		lifeSlider.maxValue = totalLife;
		lifeSlider.value = currentLife;
		manaSlider.maxValue = totalMana;
		manaSlider.value = currentMana;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSlider.value = currentLife;
		manaSlider.value = currentMana;
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
	public int getCurrentLife(){
		return currentLife;
	}
	public void setCurrentLife(int life){
		currentLife = life;
	}
	public void changeStatus(){

	}
	private void charDie(){
		onDie ();
	}
	protected abstract void onDie();
}
