using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

	private Animator _animator;
	private BoxCollider2D _collider;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	// part l'animation de déploiement du pont et désactive le collider
	public void Deploy () {
		_animator.SetBool("isPowered", true);
		_collider.enabled = !_collider.enabled;
	}
	
	// part l'animation de fermeture du pont et désactive le collider
	public void Shut () {
		_animator.SetBool("isPowered", false);
		_collider.enabled = !_collider.enabled;
	}
}
