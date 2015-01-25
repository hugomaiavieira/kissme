using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	public float speed;

	Material currentMaterial;
	float offset;
	GameController gameController;

	void Start () {
		gameController  = FindObjectOfType(typeof(GameController)) as GameController;
		currentMaterial = renderer.material;
	}


	void Update () {
		if (!gameController.isStatic) {
			offset += 0.001f;
			
			currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset*speed, 0));
		}
	}
}
