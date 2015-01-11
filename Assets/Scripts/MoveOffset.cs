using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	public float speed;
	Material currentMaterial;
	float offset;

	void Start () {
		currentMaterial = renderer.material;
	}

	void Update () {
		offset += 0.001f;
		
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset*speed, 0));
	}
}
