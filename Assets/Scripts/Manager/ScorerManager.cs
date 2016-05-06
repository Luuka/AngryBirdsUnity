using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorerManager : MonoBehaviour {

	public GameObject scoreUiText;

	private int score = 0;

	public void increaseScore(int val) {
		score += val;
		this.updateScreen ();
	}

	private void updateScreen() {
		this.scoreUiText.GetComponent<Text>().text = this.score.ToString();
	} 
}
