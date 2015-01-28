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

	public GameObject			initialImage;
	public List<GameObject>		finalImages;
	public AirplaneBehaviour	airplane;
	public GameObject			finishImage;

	Animator       	animator;

	FinalLevelGameState  currentState = FinalLevelGameState.WAITGAME;

	void Start () {
		StartCoroutine(DelayedStart());
	}
	
	void Update () {
		switch(currentState) {
			case FinalLevelGameState.FINISH: {
				if(TouchEvent())
					finishImage.SetActive(true);
			}
			break;
		}
	}

	public IEnumerator DelayedStart() {
		yield return new WaitForSeconds(4f);

		Fading fading = GetComponent<Fading>();
		fading.BeginFade(1);
		yield return new WaitForSeconds(fading.fadeSpeed);
		initialImage.SetActive(false);
		fading.BeginFade(-1);

		currentState = FinalLevelGameState.INITIALANIMATION;
		Animator animator = airplane.GetComponent<Animator>();
		animator.SetTrigger("Takeoff");
	}

	public void StartIlustrationSequence() {
		currentState = FinalLevelGameState.ILUSTRATIIONSEQUENCE;
		StartCoroutine(ShowIlustrationSequence());
	}
	

	public IEnumerator ShowIlustrationSequence() {
		Fading fading = GetComponent<Fading>();
		float interval = 4f;

		for (int i=0; i < finalImages.Count; i++) {
			bool isLastImage = (i == finalImages.Count - 1);

			fading.BeginFade(1);
			yield return new WaitForSeconds(fading.fadeSpeed);
			if (isLastImage) yield return new WaitForSeconds(3f);
			finalImages[i].SetActive(true);
			fading.BeginFade(-1);
			
			yield return new WaitForSeconds(interval);
			if(isLastImage) currentState = FinalLevelGameState.FINISH;
		}
	}
	
	public bool TouchEvent() {
		return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
	}
}
