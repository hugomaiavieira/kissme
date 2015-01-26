using UnityEngine;
using System.Collections;

public class AirplaneBehaviour : MonoBehaviour {

	public void PlayTakeoffSound() {
		SoundController.PlaySound(gameSounds.airplane);
	}
}
