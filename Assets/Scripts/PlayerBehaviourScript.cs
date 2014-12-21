using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {

	public float flyForce;

	void Start () {
		
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
			Fly();
	}

	private void Fly() {
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(new Vector2(0, 1) * flyForce);
	}
}
