using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	[SerializeField]
	private Transform _laserEmitter;
	[SerializeField]
	private Transform _persoRef;
	[SerializeField]
	private LayerMask _raycastLayerMask;
	[SerializeField]
	private HealthBar _healthBarRef;
	[SerializeField]
	private Texture _textureLaser;
	private float _laserDistance = 4f;
	private float _laserLongueur = 4f;
	private Vector2 direction;
	private Animator _animator;
	private AudioSource _audio;
	private bool _audioToggle;
	

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		followPerso(_raycastLayerMask);
	}

	//Dessine un rayon laser devant la tourelle
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        direction = transform.TransformDirection(Vector2.left) * _laserLongueur;
        Gizmos.DrawRay(_laserEmitter.position, direction);
        // Gizmos.DrawGUITexture(new Rect(_laserEmitter.position.x, _laserEmitter.position.y, 1, 2), _textureLaser);
    }

	//Raycast de suivi du personnage
	void followPerso(LayerMask layerMask) {
		float deltaX = transform.position.x - _persoRef.position.x;
		float deltaY = transform.position.y - _persoRef.position.y;
		float angle = Mathf.Atan2(deltaY,deltaX) * Mathf.Rad2Deg;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _laserDistance, layerMask);
		if(hit.collider != null && hit.collider.name=="PersoContainer" && angle <= 40 && angle >= -40){
			_laserLongueur = Vector2.Distance(_persoRef.position,transform.position);
			transform.rotation = Quaternion.Euler(0,0,angle);
			_animator.applyRootMotion = true;
			if(_healthBarRef.IsHit != true){
				_healthBarRef.IsHit = true;
			}
			if(_audioToggle){
				_audio.Play();
				_audioToggle = !_audioToggle;
			}
		} else if(hit.collider != null && hit.collider.name=="Panels"){
			_laserLongueur = hit.distance;	//Empêche le laser de traverser l'obstacle
			_animator.applyRootMotion = false;
			if(_healthBarRef.IsHit != false){
				_healthBarRef.IsHit = false;
			}
			_audio.Stop();
			_audioToggle = true;
		} else {
			_laserLongueur = 4f;
			_animator.applyRootMotion = false;
			if(_healthBarRef.IsHit != false){
				_healthBarRef.IsHit = false;
			}
			_audio.Stop();
			_audioToggle = true;
		}
	}
}