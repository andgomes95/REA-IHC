using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameState{
	BATTLE,
	PRE_BATTLE,
	WIN,
	LOSE
}
public enum BattleState{
	WAITING,
	YOUR_TURN,
	ANIMATION_ATTACK,
	ENEMY_TURN
}

public class GamePlayController : MonoBehaviour {

	public GameState currentGameState = GameState.PRE_BATTLE;
	private GameState nextGameState;

	public BattleState currentBattleState = BattleState.WAITING;
	private BattleState nextBattleState;

	//General
	public PlayerBehaviour player;
	private AttackBase selectedAttack;

	//UI
	public GameObject preBattleUI;
	public GameObject attackSelectUI;
	public GameObject defenseSelectUI;

	//AttackInfo
	public Dropdown attackList;
	public Text damageValue;
	public Text typeValue;
	public Text manaCostValue;

	// Use this for initialization
	void Start () {
		ChangeGameState (GameState.PRE_BATTLE);
		ChangeBattleState (BattleState.WAITING);
		attackList.options = player.getAttackNames ();
	}
	
	// Update is called once per frame
	void Update () {
		gameStateMachine ();
	}
	private void gameStateMachine(){
		currentGameState = nextGameState;
		switch (currentGameState) {
		case GameState.PRE_BATTLE:
			break;
		case GameState.BATTLE:
			battleStateMachine ();
			break;
		case GameState.WIN:
			break;
		case GameState.LOSE:
			break;
		}
	}
	private void battleStateMachine(){
		currentBattleState = nextBattleState;
		switch (currentBattleState) {
		case BattleState.WAITING:
			break;
		case BattleState.YOUR_TURN:
			break;
		case BattleState.ANIMATION_ATTACK:
			break;
		case BattleState.ENEMY_TURN:
			break;
		}
	}
	public void BackToPhaseSelect(){
		SceneManager.LoadScene ("PhaseSelect");
	}
	public void StartBattle(){
		ChangeGameState (GameState.BATTLE);
	}

	public void ChangeGameState(GameState newState){
		nextGameState = newState;
		switch (nextGameState) {
		case GameState.PRE_BATTLE:
			break;
		case GameState.BATTLE:
			ChangeBattleState (BattleState.YOUR_TURN);
			preBattleUI.SetActive (false);
			break;
		case GameState.WIN:
			break;
		case GameState.LOSE:
			break;
		}
	}

	public void ChangeBattleState(BattleState newState){
		nextBattleState = newState;
		switch (nextBattleState) {
		case BattleState.WAITING:
			break;
		case BattleState.YOUR_TURN:
			break;
		case BattleState.ANIMATION_ATTACK:
			break;
		case BattleState.ENEMY_TURN:
			break;
		}
	}


	//Battle Actions
	public void openAttackSelection(){
		defenseSelectUI.SetActive (false);
		attackSelectUI.SetActive (true);
		SelectAttack ();

	}
	public void openDefenseSelection(){
		attackSelectUI.SetActive (false);
		defenseSelectUI.SetActive (true);
	}
	public void tryRun(){

	}
	public void wait(){

	}
	public void SelectAttack(){
		selectedAttack = player.attacks [attackList.value];
		damageValue.text = selectedAttack.damageAttack.ToString();
		typeValue.text = selectedAttack.typeAttack.ToString ();
		manaCostValue.text = selectedAttack.manaAttack.ToString ();
	}
}
