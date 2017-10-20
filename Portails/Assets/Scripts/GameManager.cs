using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Permet de récupérer le Game Manager rapidement
	public static GameManager instance;

	void Start(){
		//Conserve le GameObject dans les autres scènes
		if(instance != null){
			Destroy(gameObject,0);
		} else {
			instance = this;
		}
	}

	public void Jouer(){
		SceneManager.LoadScene("Jeu");
	}

	public void Menu(){
		SceneManager.LoadScene("Menu");
	}
}
