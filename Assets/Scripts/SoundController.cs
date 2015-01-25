using UnityEngine;
using System.Collections;

public enum gameSounds {
	die,
	hit,
	kiss,
	pop,
	wing
}

public class SoundController : MonoBehaviour {
	
	public AudioClip soundDie;
	public AudioClip soundHit;
	public AudioClip soundKiss;
	public AudioClip soundPop;
	public AudioClip soundWing;
	
	public static SoundController instance;
	
	
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public static void PlaySound (gameSounds currentSound) {
		switch(currentSound) {
			case gameSounds.die: {
				instance.audio.PlayOneShot(instance.soundDie);
			} break;
			case gameSounds.hit: {
				instance.audio.PlayOneShot(instance.soundHit);
			} break;
			case gameSounds.wing: {
				instance.audio.PlayOneShot(instance.soundWing);
			} break;
			case gameSounds.kiss: {
				instance.audio.PlayOneShot(instance.soundKiss);
			} break;
			case gameSounds.pop: {
				instance.audio.PlayOneShot(instance.soundPop);
			} break;
		}
	}
}
