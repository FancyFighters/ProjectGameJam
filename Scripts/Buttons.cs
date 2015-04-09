using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play() {
		Application.LoadLevel(1);
	}

	public void Quit() {
		Application.Quit();
	}

	public void LoadStartscreen() {
		Application.LoadLevel(0);
	}

	public void LoadCredits() {
		Application.LoadLevel(2);
	}

	public void LoadTutorial() {
		Application.LoadLevel(3);
	}
}
