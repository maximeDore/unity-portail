using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	[SerializeField]
	private Transform _laserEmitter;
	[SerializeField]
	private Transform _persoRef;
	[SerializeField]
	private LayerMask raycastLayerMask;
	private float _laserDistance = 4f;
	private float _laserLongueur = 4f;
	private float angle;
	private Vector3 direction;
	private float distance;

	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = transform.position.x - _persoRef.position.x;
		float deltaY = transform.position.y - _persoRef.position.y;
		angle = Mathf.Atan2(deltaY,deltaX) * Mathf.Rad2Deg;

		// Suis le perso s'il est dans son champs de vision de 80deg
		if(deltaX > _laserDistance*-1 && deltaX < _laserDistance && deltaY > _laserDistance*-1 && deltaY < _laserDistance && (angle <= 40 && angle >= -40)){
			isSeeingPerso();
		} else {
			_laserLongueur = 4f;
			_animator.applyRootMotion = false;
		}
	}

	//Dessine un rayon laser devant la tourelle
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.left) * _laserLongueur;
        Gizmos.DrawRay(_laserEmitter.position, direction);
    }

	bool isSeeingPerso() {
		_laserLongueur = Vector2.Distance(_persoRef.position,transform.position);
		transform.rotation = Quaternion.Euler(0,0,angle);
		_animator.applyRootMotion = true;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, raycastLayerMask);

		return hit.collider==null;
	}
}
