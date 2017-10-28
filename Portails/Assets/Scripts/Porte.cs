using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour {

	private Animator _animator;
	private bool opened = false;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}

	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	//Ouvre la porte si le joueur est assez proche
	void OnTriggerEnter2D(Collider2D other) {
		if(opened == false) {
			_animator.SetBool("isOpened", true);
			opened = true;
		}
	}

	// Ferme la porte si le joueur s'éloigne
	void OnTriggerExit2D(Collider2D other) {
		if(opened == true) {
			_animator.SetBool("isOpened", false);
			opened = false;
		}
	}
}
