using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	
	public GameObject optionMenu;
	public GameObject menuScreen;

	public void Play()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Time.timeScale = 1f;
	}

	public void Options()
	{
		optionMenu.SetActive(true);
		menuScreen.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
