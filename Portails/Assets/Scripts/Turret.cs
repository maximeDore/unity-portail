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
	private Transform _laserTexture;
	private const float _LASERDEFAULTSCALE = 2.05f;
	private float _rapportScale;
	private const float _LASERDISTANCE = 4f;	//Portée maximale de la tourelle
	private float _laserLongueur = 4f;			//Longeur du rayon laser
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
    }

	//Raycast de suivi du personnage
	void followPerso(LayerMask layerMask) {
		_rapportScale = _LASERDEFAULTSCALE/_LASERDISTANCE;	//rapport de taille du sprite du laser selon la longueur du Ray en gizmo
		_laserTexture.localScale = new Vector3(0.25f,_laserLongueur*_rapportScale,1);	//Affiche la texture du laser
		//Calcul de l'angle selon la position du personnage relativement à la tourelle
		float deltaX = transform.position.x - _persoRef.position.x;
		float deltaY = transform.position.y - _persoRef.position.y;
		float angle = Mathf.Atan2(deltaY,deltaX) * Mathf.Rad2Deg;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _LASERDISTANCE, layerMask);
		if(hit.collider != null && hit.collider.name=="PersoContainer" && angle <= 40 && angle >= -40){	//si le raycast détecte le perso et qu'il est dans le champs de vision
			_laserLongueur = Vector2.Distance(_persoRef.position,transform.position);
			transform.rotation = Quaternion.Euler(0,0,angle);
			_animator.applyRootMotion = true;	//Override l'animation par programmation
			if(_healthBarRef.IsHit != true){	//permet d'appeler la fonction permettant au personnage de perdre de la vie
				_healthBarRef.IsHit = true;
			}
			if(_audioToggle){	//Fait jouer un son d'attaque
				_audio.Play();
				_audioToggle = !_audioToggle;
			}
		} else if(hit.collider != null && hit.collider.name=="Panels"){
			_laserLongueur = hit.distance;	//Empêche le laser de traverser l'obstacle
			_animator.applyRootMotion = false;
			if(_healthBarRef.IsHit != false){	//Désactive la fonction qui fait perdre de la vie
				_healthBarRef.IsHit = false;
			}
			_audio.Stop();
			_audioToggle = true;
		} else {	//valeurs par défaut
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