using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {
	
	private Material currentMaterial;
	public float speed;
	private float offset;
	
	// Use this for initialization
	void Start () {
		currentMaterial = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
		
		offset += 0.001f;
		
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset*speed, 0));
		
	}
}
