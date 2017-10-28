using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if(Time.timeScale == 1){
				PauseJeu();
			} else if(Time.timeScale == 0) {
				PlayJeu();
			}
		}
	}

	void PauseJeu() {
		_gameManager.PauseJeu();
		Time.timeScale = 0;	//Gèle la scène de jeu
	}

	void PlayJeu() {
		Time.timeScale = 1;
		_gameManager.PlayJeu();	//Dégèle la scène de jeu
	}
}
