using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	
	public float minHeight;
	public float maxHeight;
	public float rate;
	private float currentRate;
	private GameController gameController;
	
	public GameObject prefab;
	public int maxObjects;
	
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		currentRate = rate;
		
		for(int i=0; i < maxObjects; i++) {
			GameObject obj = Instantiate(prefab) as GameObject; 
			obj.SetActive(false);
			gameController.enemies.Add(obj);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// if(!gameController.IsInGame())
		//	return;
		
		currentRate	+= Time.deltaTime;
		if(currentRate > rate) {
			currentRate = 0;
			Spawn();
		}
	}
	
	private void Spawn () {
		GameObject obj = null;
		
		for(int i=0; i < maxObjects; i++) {
			if(gameController.enemies[i].activeSelf == false || gameController.enemies[i].transform.position.x < -5) {
				obj = gameController.enemies[i];
				obj.SetActive(false);
				break;
			}
		}
		
		if(obj != null) {
			obj.transform.position = new Vector3(
				transform.position.x, 
				Random.Range(minHeight, maxHeight), 
				transform.position.z
			);
			obj.SetActive(true);
		}
	}
}
