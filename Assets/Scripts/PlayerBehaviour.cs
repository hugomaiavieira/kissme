using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	int 			flyForce 		= 200;
	
	Animator       	animator;
	GameController 	gameController;
	bool 		   	isAwake   		= false;
	Vector3 	   	direction		= new Vector3(-1, 0 , 0);
	float          	backSpeed 		= 0.7f;
	float          	goToHugoSpeed	= 0.03f;
	Vector3			hugoDirection 	= new Vector3 (3, -1, 0);

	void Start () {
		animator       = GetComponent<Animator>();
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		Sleep();
	}

	void Update () {
		KeepOnBoundaries();
		DieWhenFall();
		moveToStartPosition();

		if(gameController.TouchEvent()) {
			if (gameController.IsInGame()) 
				Fly();
			else if(gameController.IsWinState()) 
				FlyToHugo();
		}
	}

	public void Wakeup() {
		gameObject.SetActive(true);
		rigidbody2D.gravityScale = 1;
		isAwake = true;
		Fly();
	}

	public void Sleep() {
		rigidbody2D.gravityScale = 0;
		gameObject.SetActive(false);
		isAwake = false;
	}

	private void moveToStartPosition() {
		if (isAwake && transform.position.x > -2f)
			transform.Translate(backSpeed * direction * Time.deltaTime);
	}

	private void Fly() {
		// this makes the Player not to gain velocity when flying or falling
		rigidbody2D.velocity = Vector2.zero;
		
		animator.SetTrigger("MakeFly");
		SoundController.PlaySound(gameSounds.wing);
		rigidbody2D.AddForce(new Vector2(0, 1) * flyForce);
	}

	public void FlyToHugo() {
		// Get the normalized (unitary) direction vector from the Player to Hugo
		direction = (hugoDirection - transform.position).normalized;
		transform.Translate(goToHugoSpeed * direction);
		Fly();
	}

	private void KeepOnBoundaries() {
		Vector3 actualPosition = transform.position;

		if (actualPosition.y > 4.7f) {
			actualPosition.y = 4.7f;
			transform.position = actualPosition;
		}

		if (actualPosition.x > 1.75f) {
			actualPosition.x = 1.75f;
			transform.position = actualPosition;
		}
	}

	private void DieWhenFall() {
		if (transform.position.y < -5.35f) gameController.CallGameOver();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.tag == "Hugo")
			gameObject.SetActive(false);
		else
			gameController.CallGameOver();
	}
}
