using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject endGameUI;

	public void endGame() {
	
	}

	public void checkLevelState() {
		if (isLevelFinished ()) {
			
			if(countPlanks() == 0) {
				endGameUI.gameObject.transform.FindChild("PopinText").GetComponent<Text>().text = "Vous avez gagné ce niveau";
				endGameUI.gameObject.transform.FindChild("NextLevelButton").gameObject.SetActive(true);
			} else {
				endGameUI.gameObject.transform.FindChild("PopinText").GetComponent<Text>().text = "Vous avez perdu ce niveau";
				endGameUI.gameObject.transform.FindChild("RestartButton").gameObject.SetActive(true);
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

		return woodPlanks.Length + icePlanks.Length;
	}
	
	public int countBirds() {
		return countStandardBirds () + countBomberBirds ();
	}

	public int countStandardBirds() {
		GameObject[] standardBirds = GameObject.FindGameObjectsWithTag ("StandardBird");
		
		int notLaunchedBird = 0;
		
		foreach(GameObject bird in standardBirds){
			if(!bird.GetComponent<Bird>().isLanded){
				notLaunchedBird++;
			}
		}
		
		return notLaunchedBird;
	}

	public int countBomberBirds() {
		GameObject[] standardBirds = GameObject.FindGameObjectsWithTag ("BomberBird");
		
		int notLaunchedBird = 0;
		
		foreach(GameObject bird in standardBirds){
			if(!bird.GetComponent<Bird>().isLanded){
				notLaunchedBird++;
			}
		}
		
		return notLaunchedBird;
	}
}
