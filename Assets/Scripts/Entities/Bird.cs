using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public static int birdCounter = 0;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector2 originPosition;

	public GameObject BirdsLoader = null;
	public bool isLoaded = false;
	private bool isLaunched = false;

	public float maxDistance = 1;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		if (isReadyToDrag()) {
			CameraManager.mouseState = "pullBird";
			
			this.originPosition = this.transform.position;
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}

	void OnMouseUp() {
		if (isReadyToDrag()) {
			CameraManager.mouseState = "flying";
			this.isLaunched = true;
			Bird.birdCounter++;

			Vector2 orientation = new Vector2 (this.transform.position.x, this.transform.position.y) - originPosition;
			Vector2 baseVector = new Vector2 (this.originPosition.x - maxDistance, this.originPosition.y) - this.originPosition;

			Debug.DrawLine (this.originPosition, new Vector2 (this.transform.position.x, this.transform.position.y), Color.red, 1000000f, true);
			/*Debug.DrawLine (this.originPosition, new Vector2(this.originPosition.x-maxDistance, this.originPosition.y), Color.blue, 1000000f,true);*/

			float angle = Vector2.Angle (orientation, baseVector);

			Debug.Log ("ADD FORCE");
			//this.GetComponent<Rigidbody2D> ().AddForce (orientation * -50000, ForceMode2D.Impulse);
			this.GetComponent<Rigidbody2D> ().gravityScale = 1;
			this.GetComponent<Rigidbody2D> ().velocity = orientation * -15;
		}

	}
	
	void OnMouseDrag(){
		if (isReadyToDrag()) {
			Vector2 curScreenPoint = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector2 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
			
			if (Vector2.Distance (curPosition, this.originPosition) > 1f) {
				Vector2 maxPosition = (curPosition - this.originPosition).normalized * 1f + this.originPosition;
				this.transform.position = maxPosition;
			} else {
				this.transform.position = curPosition;
			}
		}
	}

	bool isReadyToDrag() {
		return !isLaunched && isLoaded;
	}

	public void OnCollisionEnter2D(Collision2D col) {

			CameraManager.mouseState = "normal";

			if(BirdsLoader != null) {
				Bird nextBird = BirdsLoader.transform.GetChild(birdCounter-1).gameObject.GetComponent<Bird>();
				if(!nextBird.isLaunched) {
					nextBird.BirdsLoader = this.BirdsLoader;
					nextBird.transform.position = this.originPosition;
					nextBird.isLoaded = true;
					this.BirdsLoader = null;
					Camera.main.GetComponent<CameraManager>().BirdToFollow = nextBird.gameObject;
				}
			}

		
	}
	
}
