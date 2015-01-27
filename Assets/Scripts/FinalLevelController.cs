using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum FinalLevelGameState {
	WAITGAME,
	INITIALANIMATION,
	ILUSTRATIIONSEQUENCE,
	FINISH
}

public class FinalLevelController : MonoBehaviour {

	public List<GameObject>		finalImages;
	public AirplaneBehaviour	airplane;

	Animator       	animator;

	FinalLevelGameState  currentState = FinalLevelGameState.WAITGAME;

	void Start () {

	}
	
	void Update () {
		Debug.Log(currentState);

		switch(currentState) {
			case FinalLevelGameState.WAITGAME: {
				if(TouchEvent()) {
					currentState = FinalLevelGameState.INITIALANIMATION;
					Animator animator = airplane.GetComponent<Animator>();
					animator.SetTrigger("Takeoff");
				}
			}
			break;
		}
	}

	public void StartIlustrationSequence() {
		currentState = FinalLevelGameState.ILUSTRATIIONSEQUENCE;
		StartCoroutine(ShowIlustrationSequence());
	}
	

	public IEnumerator ShowIlustrationSequence() {
		Fading fading = GetComponent<Fading>();
		float interval = 4f;

		for (int i=0; i < finalImages.Count; i++) {
			fading.BeginFade(1);
			yield return new WaitForSeconds(fading.fadeSpeed);
			finalImages[i].SetActive(true);
			fading.BeginFade(-1);
			
			yield return new WaitForSeconds(interval);
		}
	}
	
	public bool TouchEvent() {
		return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
	}
}
