using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D other)	{
		_gameManager.FinJeu();
	}
}
