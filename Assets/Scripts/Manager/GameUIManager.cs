using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System;
using System.Linq;
using System.Collections.Generic;

public class GameUIManager : MonoBehaviour {

	public GameObject pauseButton;
	public GameObject pauseUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickPauseButton() {
		Time.timeScale = 0;
		this.pauseButton.GetComponent<Button> ().interactable = false;
		this.pauseUI.SetActive(true);
	}

	public void onClickClosePopinButton() {
		Time.timeScale = 1;
		this.pauseButton.GetComponent<Button> ().interactable = true;
		this.pauseUI.SetActive(false);
	}
	
	public void onClickRestartPausePopin() {
		Bird.birdCounter = 0;
		CameraManager.mouseState = "normal";
		Application.LoadLevel(Application.loadedLevel);
	}

	public void onClickNextLevelButton(){
		Bird.birdCounter = 0;
		CameraManager.mouseState = "normal";

		string actualLevelName = Application.loadedLevelName;
		int numberLevelName    = Int32.Parse(actualLevelName.Substring(actualLevelName.Length - 1)) + 1;

		if(numberLevelName <= 3){
			Application.LoadLevel ("Level" + numberLevelName);
		}else{
			Application.LoadLevel("MainMenu");
		}

	}
}
