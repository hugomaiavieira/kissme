using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {

	public float flyForce;

	GameObject animationCamera;
	GameObject dynamicCamera;

	void Start () {
		// This camera things must be on GameController
		animationCamera = GameObject.FindWithTag("AnimationCamera");
		dynamicCamera   = GameObject.FindWithTag("DynamicCamera");
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
			Fly();

		// This camera things must be on GameController
		if(Input.GetKeyDown(KeyCode.D)) {
			animationCamera.SetActive(false);
			dynamicCamera.SetActive(true);
		}

		if(Input.GetKeyDown(KeyCode.A)) {
			animationCamera.SetActive(true);
			dynamicCamera.SetActive(false);
		}
			
	}

	private void Fly() {
		// this makes the Player not to gain velocity when flying or falling
		rigidbody2D.velocity = Vector2.zero;

		rigidbody2D.AddForce(new Vector2(0, 1) * flyForce);
	}
}
