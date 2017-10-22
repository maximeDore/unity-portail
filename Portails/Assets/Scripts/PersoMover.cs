using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMover : MonoBehaviour {

	// Propriétés
	private float _speed = 2f;
	private Animator _animator;
	private Rigidbody2D _rb;
	private CircleCollider2D _collider;
	private float _horizontal;
	private float _vertical;
	private float _fire;
	// private float _vie = 1f;


	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
		_collider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_rb.bodyType == RigidbodyType2D.Kinematic){
			_rb.bodyType = RigidbodyType2D.Dynamic;
		}
		// _horizontal = Input.GetAxis("Horizontal");
		_vertical = Input.GetAxis("Vertical");
		// _fire = Input.GetAxis("Fire1");

		// if(_fire!=0){
		// 	_animator.SetTrigger("isShooting");
		// }
	}

	void FixedUpdate() {
	// 	//On détermine si une touche de mouvement est enfoncée
		bool isRunning = _vertical != 0;
		_animator.SetBool("isRunning", isRunning);
		//Permet de convertir les coordonnées du curseur de pixels à des unités de Unity
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float deltaY = mousePos.y - transform.position.y;
		float deltaX = mousePos.x - transform.position.x;

		//Récupère mon angle entre les deux points et le converti en degrés
		float angle = Mathf.Atan2(deltaY,deltaX) * Mathf.Rad2Deg;

		_rb.rotation = angle+90;

		
		//Calcule la distance entre le perso et le curseur
		float distance = Vector2.Distance(mousePos,transform.position);

		//Si la distance est supérieur au rayon du perso
		if(distance>_collider.radius && isRunning){
			//Déplacement vers le curseur
			_rb.velocity = new Vector2(deltaX,deltaY).normalized * _speed * _vertical;
		}else{
			//Pas de déplacement
			_rb.velocity = Vector2.zero;
		}
	}
}
