using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMover : MonoBehaviour {

	// Propriétés
	private float _speed = 3f;
	private Animator _animator;
	private Rigidbody2D _rb;
	private CircleCollider2D _collider;
	private float _horizontal;
	private float _vertical;
	private float _fire;


	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
		_collider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// _horizontal = Input.GetAxis("Horizontal");
		_vertical = Input.GetAxis("Vertical");
		// _fire = Input.GetAxis("Fire1");

		// if(_fire!=0){
		// 	_animator.SetTrigger("isShooting");
		// }
	}

	void FixedUpdate() {
	// 	//On détermine si une touche de mouvement est enfoncée avec un boolean
	// 	bool isTurning = _horizontal != 0;
		bool isRunning = _vertical != 0;

	// 	//Animation du personnage qui cours ou idle
		// _animator.SetBool("isRunning", isRunning);
	// 	//Mouvement du personnage avant/arrière
	// 	if(isRunning){
	// 		transform.Translate(Vector3.down * _vertical * Time.deltaTime * _speed);
	// 		// _rb.velocity = (new Vector2(0,_horizontal * _speed));
	// 	} else {
	// 		// _rb.velocity = Vector2.zero;
	// 	}
	// 	//Rotation du personnage gauche/droite
	// 	if(isTurning) {
	// 		transform.Rotate (Vector3.back * _horizontal * _speed);
	// 		// _rb.rotation = _vertical * _speed;
	// 		// _rb.AddTorque(_)
	// 	}
	// }
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
