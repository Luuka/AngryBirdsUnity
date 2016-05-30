using UnityEngine;
using System.Collections;

public class BomberBird : Bird {

	public GameObject bombsModel;
	private bool hasLaunchedBombs = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isLaunched && !this.isLanded && this.isMoving () && !hasLaunchedBombs) {
			if(Input.GetMouseButtonDown(0)) {
				hasLaunchedBombs = true;

				float offsetX = -0.5f;

				for (int i=0;i<3;i++) {
					Vector2 bombPos = new Vector2(this.transform.position.x-offsetX, this.transform.position.y - 0.5f);
					offsetX++;
					GameObject bomb = Instantiate(bombsModel,bombPos, Quaternion.identity) as GameObject;

					Vector2 force = bombPos + new Vector2(bombPos.x+2, bombPos.y-2);
					bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(bombPos.x+2, bombPos.y-2)*3, ForceMode2D.Impulse);
				}

				CameraManager.mouseState = "normal";

			}
		}
	}
}
