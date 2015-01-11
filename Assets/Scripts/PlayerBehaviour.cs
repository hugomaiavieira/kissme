using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float flyForce;
	
	Animator       animator;
	GameController gameController;

	void Start () {
		animator       = GetComponent<Animator>();
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
	}

	void Update () {
		KeepMaxHeight();
		DieWhenFall();

		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
			Fly();
			
	}

	private void Fly() {
		// this makes the Player not to gain velocity when flying or falling
		rigidbody2D.velocity = Vector2.zero;

		animator.SetTrigger("MakeFly");
		rigidbody2D.AddForce(new Vector2(0, 1) * flyForce);
	}

	private void KeepMaxHeight() {
		Vector3 actualPosition = transform.position;
		if (actualPosition.y > 4.7f) {
			actualPosition.y = 4.7f;
			transform.position = actualPosition;
		}
	}

	private void DieWhenFall() {
		if (transform.position.y < -5.35f) {
			gameController.CallGameOver();
		} 
	}

	void OnCollisionEnter2D(Collision2D coll) {
		gameController.CallGameOver();
	}
}
