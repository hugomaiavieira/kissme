﻿using UnityEngine;
using System.Collections;

public class HugoBehaviour : MonoBehaviour {

	GameController gameController;
	Animator       animator;
	
	Vector3 	   direction   = new Vector3(-1, 0 , 0);
	float          speed	   = 1.23f; // must be the same as the backgound
	bool 		   animStarted = false;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		animator       = GetComponent<Animator>();

		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {		
		// Move the animation for the letf, put it in the scene
		if (gameController.IsWinState() && transform.position.x > 1.8 )
			transform.Translate(speed * direction * Time.deltaTime);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		// Start the animation
		if (!animStarted) {
			animStarted = true;
			animator.SetTrigger("ReceiveKiss");
		}
	}

	public void Activate() {
		gameObject.SetActive(true);
	}

}