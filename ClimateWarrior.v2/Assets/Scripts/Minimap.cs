using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
	public GameObject playerMarker;
	public GameObject player;

    // Update is called once per frame
    void Update()
    {
        playerMarker.transform.position = new Vector3(player.transform.position.x, playerMarker.transform.position.y, player.transform.position.z);
    }
}
