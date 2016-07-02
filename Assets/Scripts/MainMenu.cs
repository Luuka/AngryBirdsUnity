using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void loadFirstLevel() {
		Application.LoadLevel ("Level1");
	}

	public void quitGame() {
		Application.Quit ();
	}

}
