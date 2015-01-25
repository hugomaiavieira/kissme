using UnityEngine;
using System.Collections;

public class AliceBehaviour : MonoBehaviour {

	GameController gameController;
	Animator       animator;

	Vector3 	   direction   = new Vector3(-1, 0 , 0);
	float          speed	   = 1.23f; // must be the same as the backgound
	bool 		   animStarted = false;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		animator       = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Start the animation
		if (!animStarted && gameController.IsInitialAnimation()) {
			animator.SetTrigger("SendKiss");
			animStarted = true;
		}

		// Move the animation for the letf, out of the scene
		if (renderer.isVisible && gameController.IsInGame())
			transform.Translate(speed * direction * Time.deltaTime);
	}

	// After finish the initial animation, the game must start
	public void AfterFinishAnimation() {
		gameController.StartGame();
	}

	public void PlayKissSound() {
		SoundController.PlaySound(gameSounds.kiss);
	}

	public void PlayPopSound() {
		SoundController.PlaySound(gameSounds.pop);
	}
}
