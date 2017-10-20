using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	[SerializeField]
	private Transform _portal;
	public static bool _cooldown = false;
	public static float _cooldownDuration = 999f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Téléporte le joueur vers l'autre portail lorsqu'il touche le portail
	void OnTriggerStay2D(Collider2D other){
		Invoke("Cooldown",1);
		if(other.gameObject.tag == "Perso" && _cooldown == false){
			other.transform.position = _portal.transform.position;
			other.transform.Rotate (Vector3.back*180);
			Warp._cooldown = true;
		}
	}

	void Cooldown(){
		Warp._cooldown = false;
	}
}
