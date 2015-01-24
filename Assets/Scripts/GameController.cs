﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	WAITGAME,
	INGAME,
	INITIALANIMATION,
	WINSTATE,
	FINALIALANIMATION,
	GAMEOVER
}

public class GameController : MonoBehaviour {
	
	public PlayerBehaviour  player;
	public HugoBehaviour	hugo;
	public Texture2D		finalImage;
	public List<GameObject> enemies;

	int        score;
	//GameObject animationCamera;
	//GameObject dynamicCamera;
	public GameState  currentState = GameState.WAITGAME;
	
	// Use this for initialization
	void Start () {
		score           = 0;
		//animationCamera = GameObject.FindWithTag("AnimationCamera");
		//dynamicCamera   = GameObject.FindWithTag("DynamicCamera");
	}
	
	// Update is called once per frame
	void Update () {

		if(score == 1)
			StartWin();

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
			}
			break;

		}
	}
	
	public void StartGame() {
		currentState = GameState.INGAME;
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

	public bool IsWinState() {
		return currentState == GameState.WINSTATE;
	}

	public bool IsFinalAnimation() {
		return currentState == GameState.FINALIALANIMATION;
	}
	
	public void CallGameOver() {
		currentState = GameState.GAMEOVER;
		// show the die message and restart the level

		StartCoroutine(ResetLevel());
	}

	IEnumerator ResetLevel() {
		float fadeTime = GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevel);
	}

	public IEnumerator Fade() {
		float fadeTime = GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		GetComponent<Fading>().BeginFade(-1);
	}

	public void StartWin() {
		currentState = GameState.WINSTATE;
		hugo.Activate();
		InactiveInvisibleEnemies();
	}

	public void StartFinalAnimation() {
		currentState = GameState.FINALIALANIMATION;

		Fading fading = GetComponent<Fading>();
		fading.fadeOutTexture = finalImage;
		float fadeTime = fading.BeginFade(1);
	}
	
	public void InactiveInvisibleEnemies() {
		foreach(GameObject enemy in enemies) {
			if (!enemy.renderer.isVisible)
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
