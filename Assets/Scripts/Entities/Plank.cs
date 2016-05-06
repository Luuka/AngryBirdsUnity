using UnityEngine;
using System.Collections;

public class Plank : MonoBehaviour {

	public GameObject puffSprite;

	public float standardBirdResistance;
	public float woodPlankResistance;
	public float groundResistance;
	public float icePlankResistance;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D col) {

		GameObject go = col.gameObject;


		switch (go.tag) {
		case "StandardBird":
			if(isOverBreakPointVelocity(col, this.standardBirdResistance)) {
				destroyTargetWithPuff(this.gameObject);
			}
			break;
		case "WoodPlank":
			if(isOverBreakPointVelocity(col, this.woodPlankResistance)) {
				destroyTargetWithPuff(this.gameObject);
			}
			break;
		case "Ground":
			if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > this.groundResistance) {
				destroyTargetWithPuff(this.gameObject);
			}
			break;
		case "IcePlank":
			if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > this.icePlankResistance) {
				destroyTargetWithPuff(this.gameObject);
			}
			break;
		default:
			break;

		}

	}

	private void destroyTargetWithPuff(GameObject goToDestroy) {
		Instantiate(puffSprite,goToDestroy.transform.position,Quaternion.identity);
		Destroy(goToDestroy);
		Camera.main.GetComponent<ScorerManager> ().increaseScore (1);
	}

	private bool isOverBreakPointVelocity(Collision2D col, float breakpoint) {

		Vector2 velocity = col.gameObject.GetComponent<Rigidbody2D> ().GetPointVelocity (col.contacts [0].point);

		if(velocity.x > breakpoint) {
			return true;
		}
		return false;
	}
}
