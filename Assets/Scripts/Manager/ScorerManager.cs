using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System;
using System.Linq;
using System.Collections.Generic;

public class ScorerManager : MonoBehaviour {

	public GameObject scoreUiText;
	public GameObject highScoreUiText;

	private int score = 0;

	void Start() {
		if (!PlayerPrefs.HasKey (getScoreName ())) {
			PlayerPrefs.SetInt (getScoreName (), 0);
			this.highScoreUiText.GetComponent<Text> ().text = "0";
		} else {
			this.highScoreUiText.GetComponent<Text>().text = PlayerPrefs.GetInt (getScoreName()).ToString();
		}
	}

	public void increaseScore(int val) {
		score += val;

		if (score > PlayerPrefs.GetInt (getScoreName())) {
			PlayerPrefs.SetInt(getScoreName(), score);
		}

		this.updateScreen ();
	}

	private void updateScreen() {
		this.scoreUiText.GetComponent<Text>().text = this.score.ToString();
		this.highScoreUiText.GetComponent<Text>().text = PlayerPrefs.GetInt (getScoreName()).ToString();

	} 

	private string getScoreName() {
		string actualLevelName = Application.loadedLevelName;
		string numberLevelName    = Int32.Parse(actualLevelName.Substring(actualLevelName.Length - 1)).ToString();
		string scoreName       = "score" + numberLevelName;

		return scoreName;
	}
}
