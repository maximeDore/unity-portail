using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	// [SerializeField]
	private float _timer = 60.00f;
	private Text _text;
	private GameManager _gameManager;

	void Start() {
		_text = GetComponent<Text>();
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_timer>0.01f){
			_timer -= Time.deltaTime;
		} else {
			_timer = 0.00f;
			_gameManager.Fin();
			this.enabled = false;
		}
		_text.text = _timer.ToString("F2");
	}
}
