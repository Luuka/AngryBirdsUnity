using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		Application.LoadLevel ("Level1");
	}
}
