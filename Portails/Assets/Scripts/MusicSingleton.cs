using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour {

	private static MusicSingleton instance = null;
	public static MusicSingleton Instance {
		get { return instance; }
	}
	
	//Si le son est en double, détruire les éléments répétitifs
	 void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);	//Conserve la musique sur la scène en tout temps
	}
}
