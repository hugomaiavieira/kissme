﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	START,
	WAITGAME,
	INGAME,
	INITIALANIMATION,
	FINALIALANIMATION,
	GAMEOVER
}

public class GameController : MonoBehaviour {
	
	public PlayerBehaviour player;
	public List<GameObject> enemies;

	GameObject animationCamera;
	GameObject dynamicCamera;
	GameState  currentState = GameState.START;
	
	// Use this for initialization
	void Start () {
		// player.SetStartPosition();
		animationCamera = GameObject.FindWithTag("AnimationCamera");
		dynamicCamera   = GameObject.FindWithTag("DynamicCamera");
	}
	
	// Update is called once per frame
	void Update () {
		// This camera things must be on GameController
		if(Input.GetKeyDown(KeyCode.D)) {
			animationCamera.SetActive(false);
			dynamicCamera.SetActive(true);
		}
		
		if(Input.GetKeyDown(KeyCode.A)) {
			animationCamera.SetActive(true);
			dynamicCamera.SetActive(false);
		}


		switch(currentState) {

			case GameState.START: {
			}
			break;

			case GameState.WAITGAME: {
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
	}
	
	public bool IsInGame() {
		return currentState == GameState.INGAME;
	}
	
	public void CallGameOver() {
		currentState = GameState.GAMEOVER;
	}
	
	public void RestartGame() {
		// player.Restart();
		foreach(GameObject enemy in enemies) {
			enemy.SetActive(false);
		}
	}
}