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

	public void Jouer() {
		if(SceneManager.sceneCount>1){
			SceneManager.UnloadSceneAsync(2);
		}
		SceneManager.LoadScene("Jeu");
		if(Time.timeScale==0){
			Time.timeScale = 1;
		}
	}

	public void Instructions() {
		SceneManager.LoadScene("Instructions");
	}

	public void Menu() {
		SceneManager.LoadScene("Menu");
		if(Time.timeScale==0){
			Time.timeScale = 1;
		}
	}

	public void Fin() {
		SceneManager.LoadScene("Failure", LoadSceneMode.Additive);
		Time.timeScale = 0;
	}

	public void FinJeu(){
		SceneManager.LoadScene("Fin");
	}

	public void PlayJeu(){
		Time.timeScale = 1;
		SceneManager.UnloadSceneAsync("PauseMenu");
	}

	public void PauseJeu(){
		Time.timeScale = 0;
		if(SceneManager.sceneCount<2){
			SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
		}
	}
}
