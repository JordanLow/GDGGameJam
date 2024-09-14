using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit();
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Level 0");
	}
}