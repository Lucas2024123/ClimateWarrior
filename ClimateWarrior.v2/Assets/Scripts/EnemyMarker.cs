using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarker : MonoBehaviour
{
   public GameObject prefab;
   public GameObject[] enemies;
   public GameObject[] enemymarkers;
   public static int updateRequest = 0;
   private int oldUpdateRequest = 0;

   void Start()
   {
   	enemies = GameObject.FindGameObjectsWithTag("Enemy");
   	foreach (GameObject enemy in enemies)
   	{
   		Vector3 pos = new Vector3(enemy.transform.position.x, 125f, enemy.transform.position.z);
   		GameObject marker = Instantiate(prefab, pos, enemy.transform.rotation);
   		marker.transform.parent = transform;
   		marker.layer=6;
   		marker.tag="EnemyMarker";
   	}
   }

   void Update()
   {
   	if (updateRequest!=oldUpdateRequest)
   	{
   		enemies = GameObject.FindGameObjectsWithTag("Enemy");
	   	enemymarkers = GameObject.FindGameObjectsWithTag("EnemyMarker");
		foreach (GameObject marker in enemymarkers)
		{
		   	Destroy(marker);
		}

		foreach (GameObject enemy in enemies)
		{
		   	Vector3 pos = new Vector3(enemy.transform.position.x, 125f, enemy.transform.position.z);
		   	GameObject marker = Instantiate(prefab, pos, enemy.transform.rotation);
		   	marker.transform.parent = transform;
		   	marker.layer=6;
		   	marker.tag="EnemyMarker";
		}
   	}
	oldUpdateRequest = updateRequest;
   	
   }
}
