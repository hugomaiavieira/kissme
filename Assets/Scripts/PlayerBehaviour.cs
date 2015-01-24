using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float flyForce;
	
	Animator       	animator;
	GameController 	gameController;
	bool 		   	isAwake   		= false;
	Vector3 	   	direction		= new Vector3(-1, 0 , 0);
	float          	backSpeed 		= 0.7f;
	float          	goToHugoSpeed	= 0.2f;
	float 		   	lastFlyghtTime	= 0;
	Vector3			hugoDirection 	= new Vector3 (3, -1, 0);

	void Start () {
		animator       = GetComponent<Animator>();
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		Sleep();
	}

	void Update () {
		KeepMaxHeight();
		DieWhenFall();
		moveToStartPosition();

		if(gameController.TouchEvent() && gameController.IsInGame())
			Fly();

		if(gameController.IsWinState())
			GoToHugo();
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

	public void GoToHugo() {
		rigidbody2D.gravityScale = 0;
		rigidbody2D.velocity = Vector2.zero;

		// Get the normalized (unitary) direction vector from the Player to Hugo
		direction = (hugoDirection - transform.position).normalized;
		
		transform.Translate(goToHugoSpeed * direction * Time.deltaTime);

		lastFlyghtTime	+= Time.deltaTime;
		if(lastFlyghtTime > 0.5f) {
			lastFlyghtTime = 0;
			animator.SetTrigger("MakeFly");
		}
	}

	private void moveToStartPosition() {
		if (isAwake && transform.position.x > -1.5f) {
			transform.Translate(backSpeed * direction * Time.deltaTime);
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
		// ver se bateu em Hugo ou em um inimigo
		//if (enemy) 
		//	gameController.CallGameOver();
		if (coll.collider.name == "Hugo") {
			gameObject.SetActive(false);
		}
			//gameController.StartFinalAnimation();
	}
}
