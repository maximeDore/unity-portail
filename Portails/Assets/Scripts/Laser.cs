using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	[SerializeField]
	private SpriteRenderer _power;
	[SerializeField]
	private Bridge _bridge;
	[SerializeField]
	private Transform _laserEmitter;
	[SerializeField]
	private Transform _cubeRef;
	private const float _LOCALSCALE = 0.9127775f;
	private BoxCollider2D _collider;

	// Use this for initialization
	void Start () {
		_collider = GetComponent<BoxCollider2D>();
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

	void OnCollisionStay2D(Collision2D other) {
		Debug.Log(_cubeRef.position);
		if(other.gameObject.tag == "Cube"){
			this.PowerOn();
			transform.localScale = new Vector3(1,Vector2.Distance(other.gameObject.transform.position,transform.position)/2,1);
			
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Cube"){
			this.PowerOff();
			transform.localScale = new Vector3(1,_LOCALSCALE,1);
		}
	}
}
