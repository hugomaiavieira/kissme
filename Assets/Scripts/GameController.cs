using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	WAITGAME,
	INITIALSTORY,
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
	public List<GameObject> initialImages;
	public List<GameObject> finalImages;
	public bool 			isStatic = true;

	int        score;
	GameState  currentState = GameState.INITIALSTORY;

	void Start () {
		score = 0;
		isStatic = true;
		StartCoroutine(PlayInitialStory());
	}

	void Update () {
		if(score == 7) {
			score++; // add one more score to not enter here anymore
			StartWin();
		}

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


		StartCoroutine(FadeImages(finalImages));
		currentState = GameState.FINISHLEVEL;
	}

	IEnumerator PlayInitialStory() {
		yield return new WaitForSeconds(5f);
		StartCoroutine(FadeInitialImages(initialImages));

		currentState = GameState.WAITGAME;
	}

	public IEnumerator FadeInitialImages(List<GameObject> images) {
		Fading fading = GetComponent<Fading>();
		float interval = 5f;
		
		for (int i=0; i < images.Count; i++) {
			fading.BeginFade(1);
			yield return new WaitForSeconds(fading.fadeSpeed);
			images[i].SetActive(true);
			fading.BeginFade(-1);
			images[i].SetActive(false);
			yield return new WaitForSeconds(fading.fadeSpeed);

			if (i != images.Count - 1) // do not add the interval for the last image
				yield return new WaitForSeconds(interval);
		}
	}


	public IEnumerator FadeImages(List<GameObject> images) {
		Fading fading = GetComponent<Fading>();
		float interval = 4f;
		
		for (int i=0; i < images.Count; i++) {
			fading.BeginFade(1);
			yield return new WaitForSeconds(fading.fadeSpeed);
			images[i].SetActive(true);
			fading.BeginFade(-1);

			if (i != images.Count - 1) // do not add the interval for the last image
				yield return new WaitForSeconds(interval);
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
