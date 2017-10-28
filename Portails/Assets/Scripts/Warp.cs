using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	[SerializeField]
	private Transform _portal;
	public static bool _cooldown = false;

	// Téléporte le joueur vers l'autre portail lorsqu'il touche le portail
	void OnTriggerStay2D(Collider2D other){
		Invoke("Cooldown",1);	//appelle la fonction avec un délai d'une seconde
		if(_cooldown == false){
			other.transform.position = _portal.transform.position;
			other.transform.Rotate (Vector3.back*180);
			Warp._cooldown = true;
		}
	}

	void Cooldown(){
		Warp._cooldown = false;
	}
}
