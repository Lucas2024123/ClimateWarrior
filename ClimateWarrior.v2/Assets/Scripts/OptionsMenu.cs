using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    
    public GameObject optionMenu;
    public GameObject menuScreen;

    public void Menu() {
    	optionMenu.SetActive(false);
    	menuScreen.SetActive(true);
    }
}
