using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float speed;

	bool            passed;
	Vector3	        direction = new Vector3(-1, 0 , 0);
	GameController  gameController;

	void OnEnable() {
		passed = false;
	}
	
	void Start () {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
	}

	void Update () {
		Attack();
		checkPlayerCrossing();
	}

	public void Attack() {
		transform.Translate(speed * direction * Time.deltaTime);
	}

	private void checkPlayerCrossing () {
		if(transform.position.x < gameController.player.transform.position.x && !passed) {
			passed = true;
			gameController.AddScore();
		}
	}

}
