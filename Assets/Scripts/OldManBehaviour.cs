using UnityEngine;
using System.Collections;

public class OldManBehaviour : MonoBehaviour {

	public float speed;

	Vector3 		direction = new Vector3(-1, 0 , 0);
	GameController 	gameController;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.IsInGame())
			transform.Translate(speed * direction * Time.deltaTime);
	}
}
