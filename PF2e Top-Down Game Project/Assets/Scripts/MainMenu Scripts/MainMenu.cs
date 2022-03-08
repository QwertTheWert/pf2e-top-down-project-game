using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

	public Animator transition;
	[SerializeField] private float transitionTime = 1f;
	[SerializeField] private int levelIndex;

	public void PlayGame () {
		StartCoroutine(LoadGame());
	}

	public void QuitGame() {
		Debug.Log("Quit!");
		Application.Quit();
	}

	IEnumerator LoadGame() {
		// Play animation
		transition.SetTrigger("Start");

		// Wait 1 Second
		yield return new WaitForSeconds(transitionTime);

		// Load GameScene
		SceneManager.LoadScene(levelIndex);
	}
}
