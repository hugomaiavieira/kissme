using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	WAITGAME,
	INGAME,
	INITIALANIMATION,
	WINSTATE,
	FINALIALANIMATION,
	FINISHLEVEL,
	GAMEOVER
}

public class GameController : MonoBehaviour {
	
	public PlayerBehaviour  player;
	public HugoBehaviour	hugo;
	public List<GameObject> enemies;
	public List<Texture2D> 	finalImages;
	public bool 			isStatic = true;

	int        score;
	GameState  currentState = GameState.WAITGAME;

	void Start () {
		score = 0;
		isStatic = true;
	}

	void Update () {
		if(score == 8) StartWin();

		switch(currentState) {
			case GameState.WAITGAME: {
				if(TouchEvent()) currentState = GameState.INITIALANIMATION;
			}
			break;

			case GameState.FINISHLEVEL: {
				if(TouchEvent()) StartCoroutine(LoadNextLevel());
			}
			break;
		}
	}
	
	public void StartGame() {
		currentState = GameState.INGAME;
		player.Wakeup();
		isStatic = false;
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
		StartCoroutine(ResetLevel());
	}

	IEnumerator ResetLevel() {
		float fadeTime = GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevel);
	}

	IEnumerator LoadNextLevel() {
		float fadeTime = GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevel + 1);
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


		StartCoroutine(FadeImages());
		currentState = GameState.FINISHLEVEL;
	}

	public IEnumerator FadeImages() {
		for (int i=0; i < finalImages.Count; i++) {
			Texture2D image = finalImages[i];

			Fading fading = GetComponent<Fading>();
			fading.fadeSpeed = 4f;
			
			fading.fadeOutTexture = image;
			float time = fading.BeginFade(1);
			yield return new WaitForSeconds(time);
			fading.fadeSpeed = 0.01f;
			fading.BeginFade(-1);
		}
	}
	
	public void InactiveInvisibleEnemies() {
		foreach(GameObject enemy in enemies) {
			if (!enemy.renderer.isVisible) enemy.SetActive(false);
		}
	}

	public void AddScore() {
		score++;
	}

	public bool TouchEvent() {
		return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
	}
}
