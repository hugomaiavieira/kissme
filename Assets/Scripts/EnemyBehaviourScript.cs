using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {

	float MAX_DISTANCE = 1.5f;

	public float speed;
	GameObject player;
	Vector3 direction;
	Vector3 directionNormalized;
	bool attacking = true;
	
	void Start () {
		player = GameObject.FindWithTag("Player");
		CalculateDirection();
	}

	void Update () {
		Attack();
	}

	// Attack the player until reaches some distance of him
	public void Attack() {
		float distance = Vector3.Distance(player.transform.position, transform.position);

		if (distance > MAX_DISTANCE && attacking) {
			CalculateDirection();
		} 
		else if (distance <= MAX_DISTANCE && attacking) {
			attacking = false;
		}

		transform.Translate(speed * direction * Time.deltaTime);
	}
	
	// Get the normalized (unitary) direction vector from the enemy to the player
	private void CalculateDirection () {
		direction = (player.transform.position - transform.position).normalized;
	}

}
