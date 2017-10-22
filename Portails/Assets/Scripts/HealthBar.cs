using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

     private float _vie = 1f; //Vie restante (max = 1)
	 private GameManager _gameManager;
	 private bool _isHit = false;
	 private Slider _healthSlider;
	 private Text _percent;
	 
	 public bool IsHit {
		 get { return _isHit; }
		 set { _isHit = value; }
	 }

	 void Start() {
		 _healthSlider = GetComponent<Slider>();
		 _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		 _percent = GameObject.Find("percent").GetComponent<Text>();
	 }
     
    //  void OnGUI() {
    //     //draw the background
    //     GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
	// 	GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
         
	// 	//draw the filled-in part

	// 	GUI.BeginGroup(new Rect(0,0, size.x * _vie, size.y));
	// 	GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
	// 	GUI.EndGroup();
    //     GUI.EndGroup();
    //  }
     
     void Update() {
		 if(_isHit){
         	_vie -= 0.5f * Time.deltaTime;
		 } else if(_vie<1) {
			 _vie += 0.1f * Time.deltaTime;
		 }
		 if(_vie<=0){
			_gameManager.Fin();
			this.enabled = false;
		 }
		_healthSlider.value = _vie;
		var percentage = Mathf.Round(_vie*100);
		_percent.text = percentage+"%";
     }


 }