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
	public List<PlayerBehaviour> players;
	private PlayerBehaviour player;
	public List<EnemyBehaviour> enemies;
	private EnemyBehaviour enemy;
	private AttackBase selectedAttack;
	private int countTurn;
	private int playersAlive;
	private int countAttack;
	private int valueEnemy;
	//UI
	public GameObject battleUI;
	public GameObject preBattleUI;
	public GameObject attackSelectUI;
	public GameObject defenseSelectUI;
	public Text PlayerName;
	public GameObject selectedPlayerPanel;

	//AttackInfo
	public Dropdown attackList;
	public Dropdown enemyList;
	public Text damageValue;
	public Text typeValue;
	public Text manaCostValue;

	// Use this for initialization
	void Start () {
		countAttack = 0;
		countTurn = 2;
		playersAlive = 2;
		ChangeGameState (GameState.PRE_BATTLE);
		ChangeBattleState (BattleState.WAITING);
		foreach (EnemyBehaviour enemyText in enemies) {
			enemyText.deadChar.enabled= false;
		}
		foreach (PlayerBehaviour playerText in players) {
			playerText.deadChar.enabled= false;
		}

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
			yourTurn ();
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
		ChangeBattleState (BattleState.YOUR_TURN);
	}

	public void ChangeGameState(GameState newState){
		nextGameState = newState;
		switch (nextGameState) {
		case GameState.PRE_BATTLE:
			preBattleUI.SetActive (true);
			battleUI.SetActive (false);
			attackSelectUI.SetActive (false);
			break;
		case GameState.BATTLE:
			preBattleUI.SetActive (false);
			battleUI.SetActive (true);
			ChangeBattleState (BattleState.YOUR_TURN);
			break;
		case GameState.WIN:
			break;
		case GameState.LOSE:
			break;
		}
	}

	public void ChangeBattleState(BattleState newState){
		int value;
		nextBattleState = newState;
		switch (nextBattleState) {
		case BattleState.WAITING:
			break;
		case BattleState.YOUR_TURN:
			yourTurn ();
			break;
		case BattleState.ANIMATION_ATTACK:
			//adicionar player animations
			enemy = enemies [valueEnemy];
			value = int.Parse (damageValue.text);
			enemy.setCurrentLife (enemy.getCurrentLife () - value);
			enemy.lifeSlider.value = enemy.getCurrentLife ();
			if (enemy.getCurrentLife () <= 0) {
				enemies.Remove (enemy);
				DestroyObject (enemy.lifeSlider,0);
				DestroyObject (enemy.manaSlider, 0);
				enemy.imageChar.enabled= false;
				enemy.deadChar.enabled= true;
				DestroyObject (enemy,0);
				Debug.Log (enemies.Count);
				countTurn = enemies.Count-1;
				if (enemies.Count == 0) {
					Debug.Log ("WIN");
					SceneManager.LoadScene("MainMenu");
				}

			}
			if (countAttack < playersAlive) {
				countAttack = countAttack + 1;
				ChangeBattleState (BattleState.YOUR_TURN);
			} else {
				countAttack = 0;
				ChangeBattleState (BattleState.ENEMY_TURN);
			}

			break;
		case BattleState.ENEMY_TURN:
			enemy = enemies [countAttack];
			selectedAttack = enemy.attacks [0];
			player.setCurrentLife (player.getCurrentLife () - int.Parse (selectedAttack.damageAttack.ToString ()));
			player.lifeSlider.value = player.getCurrentLife ();
			if (player.getCurrentLife () <= 0) {
				players.Remove (player);
				DestroyObject (player.lifeSlider,0);
				DestroyObject (player.manaSlider, 0);
				player.imageChar.enabled= false;
				player.deadChar.enabled= true;
				DestroyObject (player,0);
				Debug.Log (players.Count);
				playersAlive = players.Count-1;
				if (players.Count == 0) {
					Debug.Log ("LOSE");
					SceneManager.LoadScene("MainMenu");
				}

			}
			if (countAttack < countTurn) {
				countAttack = countAttack + 1;
				ChangeBattleState (BattleState.ENEMY_TURN);

			} else {
				countAttack = 0;
				ChangeBattleState (BattleState.YOUR_TURN);
			}
			break;
		}
	}


	//Battle Actions
	public void attackConfirmationClick (){
		ChangeBattleState (BattleState.ANIMATION_ATTACK);
	}
	private void yourTurn (){
		player = players [countAttack];
		attackList.options = player.getAttackNames ();
		enemyList.options = getEnemyNames ();
		PlayerName.text = player.namePlayer.ToString();
	}
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
		SceneManager.LoadScene ("PlayerSelect");
	}
	public void wait(){

	}
	public void SelectAttack(){
		selectedAttack = player.attacks [attackList.value];
		damageValue.text = selectedAttack.damageAttack.ToString ();
		typeValue.text = selectedAttack.typeAttack.ToString ();
		manaCostValue.text = selectedAttack.manaAttack.ToString ();
	}
	public void SelectEnemy(){
		enemy = enemies [enemyList.value];
		valueEnemy = enemyList.value;
	}
	public List<Dropdown.OptionData> getEnemyNames(){
		List<Dropdown.OptionData> names = new List<Dropdown.OptionData> ();
		foreach (EnemyBehaviour enemyText in enemies) {
			enemyText.deadChar.enabled= false;
			Dropdown.OptionData option = new Dropdown.OptionData ();
			option.text = enemyText.name;
			names.Add (option);
		}
		return names;
	}
}
