using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{   
	Vector3 lastMousePos;
	public GameObject z0;
	public GameObject z1;
	public GameObject z2;
	public GameObject z3;
	public GameObject z4;
	public GameObject z5;
	public GameObject z6;
	public Vector3 mouseDelta
	{
	    get
	    {
	    	return Input.mousePosition - lastMousePos;
	    }
	}
	void Start()
	{
	    // Initialize the value to avoid an anomalous first-frame value
	    Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
	    lastMousePos = Input.mousePosition;
	}
	void Update()
	{
	    // Use mouseDelta as needed, then update lastMousePos at
	    // the end of your Update() loop
	    z0.transform.position = new Vector3(z0.transform.position.x + mouseDelta.x*-0.015625f, z0.transform.position.y, z0.transform.position.z);
	    z1.transform.position = new Vector3(z1.transform.position.x + mouseDelta.x*0.0625f, z1.transform.position.y, z1.transform.position.z);
	    z2.transform.position = new Vector3(z2.transform.position.x + mouseDelta.x*0.03125f, z2.transform.position.y, z2.transform.position.z);
	    z3.transform.position = new Vector3(z3.transform.position.x + mouseDelta.x*0.015625f, z3.transform.position.y, z3.transform.position.z);
	    z4.transform.position = new Vector3(z4.transform.position.x + mouseDelta.x*0.0078125f, z4.transform.position.y, z4.transform.position.z);
	    z5.transform.position = new Vector3(z5.transform.position.x + mouseDelta.x*0.00390625f, z5.transform.position.y, z5.transform.position.z);
	    z6.transform.position = new Vector3(z6.transform.position.x + mouseDelta.x*0.001953125f, z6.transform.position.y, z6.transform.position.z);
	    lastMousePos = Input.mousePosition;
	}
}
