using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {

	public float speed;
	Vector3	direction = new Vector3(-1, 0 , 0);
	
	void Start () {
	}

	void Update () {
		Attack();
	}

	public void Attack() {
		transform.Translate(speed * direction * Time.deltaTime);
	}

}
