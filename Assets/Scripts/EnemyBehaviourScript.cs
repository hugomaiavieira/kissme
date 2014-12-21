using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {

	GameObject player;
	
	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	void Update () {
		// move in player's direction
	}
}
