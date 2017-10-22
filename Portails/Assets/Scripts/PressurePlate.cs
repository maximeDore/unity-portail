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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PowerOn(){
		_power.enabled = false;
		_bridge.Deploy();
	}

	public void PowerOff(){
		_power.enabled = true;
		_bridge.Shut();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Cube"){
			_nbPressed += 1;
			if(_nbPressed == 2){
				this.PowerOn();
				_laser.PowerOff();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Cube"){
			if(_nbPressed>0){
				_nbPressed -= 1;
			}
			this.PowerOff();
			_laser.PowerOn();
		}
	}
}
