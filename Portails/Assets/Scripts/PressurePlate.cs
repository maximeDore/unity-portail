using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	[SerializeField]
	private SpriteRenderer _power;
	[SerializeField]
	private Bridge _bridge;
	[SerializeField]
	private Laser _laser;
	static private int _nbPressed = 0;

	//Déploie le pont
	public void PowerOn(){
		_power.enabled = false;
		_bridge.Deploy();
	}

	//Éteint le pont
	public void PowerOff(){
		_power.enabled = true;
		_bridge.Shut();
	}

	//Détecte si un cube est sur la plaque de pression
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Cube"){
			_nbPressed += 1;
			if(_nbPressed >= 2){
				this.PowerOn();
				_laser.PowerOff();
			}
		}
	}

	//Détecte si un cube quitte la plaque de pression
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Cube"){
			if(_nbPressed>0){
				_nbPressed -= 1;
			} else if(_nbPressed<0){
				_nbPressed = 0;	//Bug où la variable devient décalée
			}
			this.PowerOff();
			_laser.PowerOn();
		}
	}
}
