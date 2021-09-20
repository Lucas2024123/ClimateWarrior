using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour
{
    public static bool GO = false;
    public GameObject gameOver;

    void Update()
    {
        if (GO) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    public void Menu()
	{	
		gameOver.SetActive(false);
		BarTimer.timeElapsed=0f;
        Time.timeScale = 1f;
        GO = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
