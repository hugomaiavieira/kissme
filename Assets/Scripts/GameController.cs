using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	WAITGAME,
	INGAME,
	INITIALANIMATION,
	FINALIALANIMATION,
	GAMEOVER
}

public class GameController : MonoBehaviour {
	
	public PlayerBehaviour  player;
	public List<GameObject> enemies;

	int        score;
	GameObject animationCamera;
	GameObject dynamicCamera;
	GameState  currentState = GameState.WAITGAME;
	
	// Use this for initialization
	void Start () {
		score           = 0;
		animationCamera = GameObject.FindWithTag("AnimationCamera");
		dynamicCamera   = GameObject.FindWithTag("DynamicCamera");

		// I don't know why I have to set active "false" and then "true" 
		// to really active the camera. If I only set to "true" it does not
		// become active.
		animationCamera.SetActive(false);
		animationCamera.SetActive(true);

		dynamicCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(score == 10)
			StartFinalAnimation();


		switch(currentState) {

			case GameState.WAITGAME: {
				if(TouchEvent())
					currentState = GameState.INITIALANIMATION;
			}
			break;

			case GameState.INITIALANIMATION: {
			}
			break;

			case GameState.FINALIALANIMATION: {
			}
			break;

			case GameState.INGAME: {
			}
			break;

			case GameState.GAMEOVER: {
				RestartGame();
			}
			break;

		}
	}
	
	public void StartGame() {
		currentState = GameState.INGAME;
		dynamicCamera.SetActive(true);
		player.Wakeup();
	}
	
	public bool IsInGame() {
		return currentState == GameState.INGAME;
	}

	public bool IsWaitingGame() {
		return currentState == GameState.WAITGAME;
	}

	public bool IsInitialAnimation() {
		return currentState == GameState.INITIALANIMATION;
	}
	
	public void CallGameOver() {
		currentState = GameState.GAMEOVER;
	}

	public void StartFinalAnimation() {
		Debug.Log("Start final animation");
	}
	
	public void RestartGame() {
		foreach(GameObject enemy in enemies) {
			enemy.SetActive(false);
		}
	}

	public void AddScore() {
		score++;
	}

	public bool TouchEvent() {
		return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
	}
}
