using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	private float _totalTime = 60.00f;
	private Text text;

	void Start() {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		_totalTime -= Time.deltaTime;
		text.text = _totalTime.ToString("F2");
	}
}
