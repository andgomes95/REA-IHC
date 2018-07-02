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
	public GameObject winOrLoseUI;
	public Text PlayerName;
	public TutorialController tutorial;
	public GameObject winText;
	public GameObject loseText;
	private int tutCount;
	public GameObject animationUI;
	public ImageAnimator enemyImage;
	public ImageAnimator playerImage;

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
		tutorial.tutorialNotAppears();
		tutCount = 0;
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
		if (ApplicationController.GetLevel () == 1 && tutCount == 0)
			tutorial.tutorialAppearsPrimary ();
		ChangeBattleState (BattleState.YOUR_TURN);
	}

	public void ChangeGameState(GameState newState){
		nextGameState = newState;
		switch (nextGameState) {
		case GameState.PRE_BATTLE:
			preBattleUI.SetActive (true);
			winOrLoseUI.SetActive (false);
			battleUI.SetActive (false);
			attackSelectUI.SetActive (false);
			animationUI.SetActive (false);
			break;
		case GameState.BATTLE:
			preBattleUI.SetActive (false);
			winOrLoseUI.SetActive(false);
			battleUI.SetActive (true);
			ChangeBattleState (BattleState.YOUR_TURN);
			break;
		case GameState.WIN:
			ApplicationController.setLevelPossible (ApplicationController.GetLevel ());
			preBattleUI.SetActive (false);
			battleUI.SetActive (false);
			winOrLoseUI.SetActive(true);
			winOrLoseText(true);
			break;
		case GameState.LOSE:
			preBattleUI.SetActive (false);
			battleUI.SetActive (false);
			winOrLoseUI.SetActive(true);
			winOrLoseText(false);
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
			preBattleUI.SetActive (false);
			battleUI.SetActive (true);
			winOrLoseUI.SetActive(false);
			winOrLoseText(false);
			yourTurn ();
			break;
		case BattleState.ANIMATION_ATTACK:
			
			StartCoroutine(Example ());
			//adicionar player animations


			break;
		case BattleState.ENEMY_TURN:
			StartCoroutine(EnemyTurn ());
			break;
		}
	}


	//Battle Actions
	public void attackConfirmationClick (){
		if (ApplicationController.GetLevel () == 1 && tutCount == 1){
			tutorial.enemyDamageTutorial();
			tutCount = tutCount+1;
		}else {
			tutorial.tutorialNotAppears();	
		}
		ChangeBattleState (BattleState.ANIMATION_ATTACK);
	}
	private void yourTurn (){
		if (enemies.Count > 0) {
			player = players [countAttack];
			attackList.options = player.getAttackNames ();
			enemyList.options = getEnemyNames ();
			PlayerName.text = player.namePlayer.ToString ();
			selectedAttack = player.attacks [attackList.value];
			damageValue.text = selectedAttack.damageAttack.ToString ();
			manaCostValue.text = selectedAttack.manaAttack.ToString ();
		}
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
		manaCostValue.text = selectedAttack.manaAttack.ToString ();
		if(ApplicationController.GetLevel() == 1 && tutCount == 0){
			tutorial.tutorialAppearsAttack();
			tutCount = tutCount+1;
		}
	}
	public void SelectEnemy(){
		enemy = enemies [enemyList.value];
		typeValue.text = ApplicationController.intToWeak(enemy.weakness).ToString();
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
	public void repeatPhase(){
		if(ApplicationController.GetLevel() == 1){
			SceneManager.LoadScene("Phase01");	
		}
		
	}
	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
	private void winOrLoseText(bool state){
		if (state == true){
			winText.SetActive(true);
			loseText.SetActive(false);
		}else{
			winText.SetActive(false);
			loseText.SetActive(true);
		}
	}
	private IEnumerator Example()
	{
		int value;
		bool saiaDoIf =  false;
		if (enemies.Count > 0) {
			enemy = enemies [valueEnemy];
			if (ApplicationController.attackToInt (selectedAttack.nameAttack) == enemy.weakness) {
				value = int.Parse (damageValue.text) * 5;
			} else {
				value = int.Parse (damageValue.text);
			}
			enemy.setCurrentLife (enemy.getCurrentLife () - value);
			enemy.lifeSlider.value = enemy.getCurrentLife ();
			playerImage.image.sprite = player.imageChar.sprite;
			playerImage.anime.runtimeAnimatorController = player.anime.runtimeAnimatorController;
			enemyImage.image.sprite = enemy.imageChar.sprite;
			enemyImage.anime.runtimeAnimatorController = enemy.anime.runtimeAnimatorController;
			animationUI.SetActive (true);
			playerImage.anime.SetBool("attack",true);
			yield return new WaitForSeconds (1);
			animationUI.SetActive (false);
			if (enemy.getCurrentLife () <= 0) {
				enemies.Remove (enemy);
				DestroyObject (enemy.lifeSlider, 0);
				DestroyObject (enemy.manaSlider, 0);
				enemy.imageChar.enabled = false;
				enemy.deadChar.enabled = true;
				DestroyObject (enemy, 0);
				countTurn = enemies.Count - 1;
				if (enemies.Count == 0) {
					ChangeBattleState (BattleState.WAITING);
					ChangeGameState (GameState.WIN);
					saiaDoIf = true;
				}

			}
			if (saiaDoIf != true) {
				if (countAttack < playersAlive) {
					countAttack = countAttack + 1;
					ChangeBattleState (BattleState.YOUR_TURN);
				} else {
					countAttack = 0;
					ChangeBattleState (BattleState.ENEMY_TURN);
					preBattleUI.SetActive (false);
					winOrLoseUI.SetActive (false);
					winOrLoseText (false);
				}
			}
		} else {
			ChangeBattleState (BattleState.WAITING);
			ChangeGameState (GameState.WIN);
		}
		enemyList.value = 0;
		valueEnemy = 0;
	}
	private IEnumerator EnemyTurn(){
		int value;
		if (players.Count > 0 && enemies.Count > 0) {
			enemy = enemies [countAttack];
			selectedAttack = enemy.attacks [0];
			if (ApplicationController.attackToInt (enemy.attacks [0].nameAttack) == player.weakness) {
				value = int.Parse (selectedAttack.damageAttack.ToString ()) * 5;
			} else {
				value = int.Parse (selectedAttack.damageAttack.ToString ());
			}
			player.setCurrentLife (player.getCurrentLife () - value);
			player.lifeSlider.value = player.getCurrentLife ();
			animationUI.SetActive (true);
			playerImage.image.sprite = player.imageChar.sprite;
			playerImage.anime.runtimeAnimatorController = player.anime.runtimeAnimatorController;
			enemyImage.image.sprite = enemy.imageChar.sprite;
			enemyImage.anime.runtimeAnimatorController = enemy.anime.runtimeAnimatorController;
			enemyImage.anime.SetBool("attack",true);
			yield return new WaitForSeconds (1);
			animationUI.SetActive (false);
			if (player.getCurrentLife () <= 0) {
				players.Remove (player);
				DestroyObject (player.lifeSlider, 0);
				DestroyObject (player.manaSlider, 0);
				player.imageChar.enabled = false;
				player.deadChar.enabled = true;
				DestroyObject (player, 0);
				playersAlive = players.Count - 1;
				if (players.Count == 0) {
					ChangeBattleState (BattleState.WAITING);
					ChangeGameState (GameState.LOSE);
				}

			}
			if (countAttack < countTurn) {
				countAttack = countAttack + 1;
				ChangeBattleState (BattleState.ENEMY_TURN);

			} else {
				countAttack = 0;
				ChangeBattleState (BattleState.YOUR_TURN);
			}
		}else if(enemies.Count > 0){
			ChangeBattleState(BattleState.WAITING);
			ChangeGameState(GameState.WIN);
		}else if (players.Count == 0) {
			ChangeBattleState(BattleState.WAITING);
			ChangeGameState(GameState.LOSE);
		}
	}

}
