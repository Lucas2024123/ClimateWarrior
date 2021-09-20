using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptionMenu : MonoBehaviour
{
    
    public GameObject optionMenu;
    public GameObject pauseMenuUI;

    public void Menu() {
    	optionMenu.SetActive(false);
    	pauseMenuUI.SetActive(true);

    }
}
