using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	private const float _LOCALSCALE = 0.9127775f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D other) {
		if(other.gameObject.tag == "Cube"){
			transform.localScale = new Vector3(1,Vector2.Distance(other.gameObject.transform.position,transform.position)/2,1);
			
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Cube"){
			transform.localScale = new Vector3(1,_LOCALSCALE,1);
		}
	}

	public void PowerOn() {
		transform.localScale = new Vector3(1,_LOCALSCALE,1);
	}

	public void PowerOff() {
		transform.localScale = new Vector3(1,0,1);
	}
}
