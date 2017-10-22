using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PauseJeu() {
		_gameManager.PauseJeu();
		Time.timeScale = 0;
	}

	void PlayJeu() {
		Time.timeScale = 1;
		_gameManager.PlayJeu();
	}
}
