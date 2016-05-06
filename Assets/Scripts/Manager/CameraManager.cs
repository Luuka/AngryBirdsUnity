using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static string mouseState = "normal";

	public GameObject BirdToFollow;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (CameraManager.mouseState) {
			case "normal" :

				Vector3 mousePosition = this.transform.position;
				
				if (Input.mousePosition.x >= (Screen.width - 50)) {
					this.transform.position =  new Vector3(mousePosition.x + 0.05f, mousePosition.y, mousePosition.z);
				}
				
				if (Input.mousePosition.x <= 50) {
					this.transform.position =  new Vector3(mousePosition.x - 0.05f, mousePosition.y, mousePosition.z);
				}

				break;

			case "flying" : 
				if (this.transform.position.x >= 0 || this.transform.position.x <= 12) {
					this.transform.position = new Vector3 (BirdToFollow.transform.position.x+5, this.transform.position.y,-10);
				}
				break;
		}

	}
}
