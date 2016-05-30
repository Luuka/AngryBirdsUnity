using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject endGameUI;

	public void endGame() {
	
	}

	public void checkLevelState() {
		if (isLevelFinished ()) {

			if(countPlanks() == 0) {
				Debug.Log ("WIN");

			} else {
				Debug.Log("LOSE");
			}

			this.endGameUI.SetActive(true);
		} else {
		
		}
	}

	private bool isLevelFinished() {
		if (countPlanks () == 0 || countBirds() == 0 || (countPlanks() == 0 && countBirds() == 0)) {
			return true;
		}
		return false;
	}

	public int countPlanks() {
		GameObject[] woodPlanks = GameObject.FindGameObjectsWithTag ("WoodPlank");
		GameObject[] icePlanks = GameObject.FindGameObjectsWithTag ("IcePlank");

		int movingPlanks = 0;

		foreach(GameObject woodPlank in woodPlanks){
			if(woodPlank.GetComponent<Rigidbody2D>().velocity.magnitude < 0.2){
				movingPlanks++;
			}
		}

		foreach(GameObject icePlank in icePlanks){
			if(icePlank.GetComponent<Rigidbody2D>().velocity.magnitude < 0.2){
				movingPlanks++;
			}
		}


		return movingPlanks;
	}
	
	public int countBirds() {
		GameObject[] standardBirds = GameObject.FindGameObjectsWithTag ("StandardBird");

		int notLaunchedStandardBird = 0;

		foreach(GameObject bird in standardBirds){
			if(!bird.GetComponent<Bird>().isLanded){
				notLaunchedStandardBird++;
			}
		}

		return notLaunchedStandardBird;
	}
}
