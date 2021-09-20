using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{

	public static bool IsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject optionMenu;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(IsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		IsPaused = false;
		
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.None;
		IsPaused = true;

	}

	public void Options()
	{
		optionMenu.SetActive(true);
		pauseMenuUI.SetActive(false);
	}


	public void Menu()
	{
		BarTimer.timeElapsed=0f;
		Time.timeScale = 1f;
		GameOverButtons.GO = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void Quit()
	{
		Application.Quit();
	}

}
