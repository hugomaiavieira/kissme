using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FotosLevelController : MonoBehaviour {

	public List<GameObject> images;
	
	void Start () {
		StartCoroutine(DelayedStart());
	}
	
	IEnumerator DelayedStart() {
		//yield return new WaitForSeconds(4f);

		Fading fading = GetComponent<Fading>();
		float interval = 4f;
		
		for (int i=0; i < images.Count; i++) {
			bool isLastImage = (i == images.Count - 1);
			
			fading.BeginFade(1);
			yield return new WaitForSeconds(fading.fadeSpeed);
			images[i].SetActive(true);
			fading.BeginFade(-1);

			//images[i].SetActive(false);
			yield return new WaitForSeconds(interval);
			
			if(isLastImage) Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
