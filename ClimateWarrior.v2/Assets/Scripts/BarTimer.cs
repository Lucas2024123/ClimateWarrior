using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BarTimer : MonoBehaviour
{

	public Text timeSurvived;

	public static float timeElapsed = 0f;
	public static float totalTimeElapsed = 0f;
	private Slider timer;
	public GameObject gameOver;

	private void Awake()
	{
		timer = gameObject.GetComponent<Slider>();
	}

    void Update()
    {
        if (timeElapsed<20)
        {
        	timeElapsed+=Time.deltaTime;
        	totalTimeElapsed+=Time.deltaTime;
        	timer.value=timeElapsed;
        }
        else if (timeElapsed>=20)
        {
        	gameOver.SetActive(true);
            GameOverButtons.GO = true;
        	string survivalTimeStr = Math.Floor(totalTimeElapsed).ToString();
        	timeSurvived.text=("You fought for " + survivalTimeStr + " seconds.");
        }
    }
}
