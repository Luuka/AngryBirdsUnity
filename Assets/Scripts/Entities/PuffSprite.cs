using UnityEngine;
using System.Collections;

public class PuffSprite : MonoBehaviour {

	private float startTime = 0;
	
	// Update is called once per frame
	void Update () {
		this.startTime += Time.deltaTime;
		if (this.startTime > 0.2f) {
			Destroy(this.gameObject);
		}

	}
}
