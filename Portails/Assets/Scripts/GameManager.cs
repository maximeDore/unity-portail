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

	//Affichage de la scène de jeu
	public void Jouer() {
		if(SceneManager.sceneCount>1){	//Détruit la scène d'échec dans le cas où elle est instantiée sur la scène de jeu
			SceneManager.UnloadSceneAsync(2);
		}
		SceneManager.LoadScene("Jeu");
		if(Time.timeScale==0){
			Time.timeScale = 1;
		}
	}

	//Affichage de la scène des instructions
	public void Instructions() {
		SceneManager.LoadScene("Instructions");
	}

	//Affichage de la scène du menu principal
	public void Menu() {
		SceneManager.LoadScene("Menu");
		if(Time.timeScale==0){
			Time.timeScale = 1;
		}
	}

	//Ajout de la scène d'échec de la partie
	public void Fin() {
		SceneManager.LoadScene("Failure", LoadSceneMode.Additive);
		Time.timeScale = 0;
	}

	//Affichage de la scène finale de succès de la partie
	public void FinJeu(){
		SceneManager.LoadScene("Fin");
	}

	//Destruction le menu pause
	public void PlayJeu(){
		Time.timeScale = 1;
		SceneManager.UnloadSceneAsync("PauseMenu");
	}

	//Ajout du menu pause
	public void PauseJeu(){
		Time.timeScale = 0;
		if(SceneManager.sceneCount<2){
			SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
		}
	}

	//Quitter l'application
	public void QuitterJeu() {
		Application.Quit();
	}
}
