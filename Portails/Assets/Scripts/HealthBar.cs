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
	 //Getter/Setter
	 public bool IsHit {
		 get { return _isHit; }
		 set { _isHit = value; }
	 }

	 void Start() {
		 _healthSlider = GetComponent<Slider>();
		 _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		 _percent = GameObject.Find("percent").GetComponent<Text>();
	 }
     
     void Update() {
		 if(_isHit){	//Si la tourelle signale que le personnage est touché
         	_vie -= 0.5f * Time.deltaTime;
		 } else if(_vie<1) {
			 _vie += 0.05f * Time.deltaTime;
		 }
		 if(_vie<=0){	//Si le personnage n'a plus de vie, le joueur perd la partie
			_gameManager.Fin();
			this.enabled = false;
		 }
		_healthSlider.value = _vie;
		var percentage = Mathf.Round(_vie*100);
		_percent.text = percentage+"%";
     }


 }