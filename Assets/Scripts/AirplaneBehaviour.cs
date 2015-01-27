using UnityEngine;
using System.Collections;

public class AirplaneBehaviour : MonoBehaviour {

	FinalLevelController gameController;

	void Start() {
		gameController = FindObjectOfType(typeof(FinalLevelController)) as FinalLevelController;
	}

	public void PlayTakeoffSound() {
		SoundController.PlaySound(gameSounds.airplane);
	}

	public void AirplaneLand() {
		gameController.StartIlustrationSequence();
	}
}
