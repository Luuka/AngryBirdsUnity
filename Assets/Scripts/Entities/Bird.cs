using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public static int birdCounter = 0;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector2 originPosition;

	public GameObject BirdsLoader = null;
	public bool isLoaded = false;
	public bool isLaunched = false;
	public bool isLanded = false;

	public float maxDistance = 1;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
		if (isLaunched && !isMoving ()) {
			this.isLanded = true;
			Camera.main.GetComponent<LevelManager> ().checkLevelState ();
			
			if(BirdsLoader != null && BirdsLoader.transform.childCount >= birdCounter) {
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
			Bird.birdCounter++;

			Vector2 orientation = new Vector2 (this.transform.position.x, this.transform.position.y) - originPosition;
			Vector2 baseVector = new Vector2 (this.originPosition.x - maxDistance, this.originPosition.y) - this.originPosition;

			float angle = Vector2.Angle (orientation, baseVector);

			this.GetComponent<Rigidbody2D> ().gravityScale = 1;
			this.GetComponent<Rigidbody2D> ().velocity = orientation * -15;

			this.isLaunched = true;
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


	public bool isMoving() {
		float speed = this.GetComponent<Rigidbody2D>().velocity.magnitude;
		if (speed > 0.2) {
			return true;
		}
		return false;
	}

	public void OnCollisionEnter2D(Collision2D col) {

		CameraManager.mouseState = "normal";

	}
	
}
