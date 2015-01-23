using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float flyForce;
	
	Animator       animator;
	GameController gameController;
	bool 		   isAwake   = false;
	Vector3 	   direction = new Vector3(-1, 0 , 0);
	float          speed	 = 1f;

	void Start () {
		animator       = GetComponent<Animator>();
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		rigidbody2D.gravityScale = 0;
	}

	void Update () {
		KeepMaxHeight();
		DieWhenFall();
		moveToStartPosition();

		if(gameController.TouchEvent() && gameController.IsInGame())
			Fly();
	}

	public void Wakeup() {
		rigidbody2D.gravityScale = 1;
		isAwake = true;
		Fly();
	}
	
	private void moveToStartPosition() {
		if (isAwake && transform.position.x > -1f) {
			transform.Translate(speed * direction * Time.deltaTime);
		}
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
