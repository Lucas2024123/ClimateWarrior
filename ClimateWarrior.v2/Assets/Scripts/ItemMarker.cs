using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMarker : MonoBehaviour
{
   public GameObject prefab;
   public GameObject[] items;
   public GameObject[] itemmarkers;
   public static int itemUpdateRequest = 0;
   private int oldItemUpdateRequest = 0;

   void Start()
   {
   	items = GameObject.FindGameObjectsWithTag("Item");
   	foreach (GameObject item in items)
   	{
   		Vector3 pos = new Vector3(item.transform.position.x, 125f, item.transform.position.z);
   		GameObject marker = Instantiate(prefab, pos, item.transform.rotation);
   		marker.transform.parent = transform;
   		marker.layer=6;
   		marker.tag="ItemMarker";
   	}
   }

   void Update()
   {
   	if (itemUpdateRequest!=oldItemUpdateRequest)
   	{
   		items = GameObject.FindGameObjectsWithTag("Item");
	   	itemmarkers = GameObject.FindGameObjectsWithTag("ItemMarker");
		foreach (GameObject marker in itemmarkers)
		{
		   	Destroy(marker);
		}

		foreach (GameObject item in items)
	   	{
	   		Vector3 pos = new Vector3(item.transform.position.x, 125f, item.transform.position.z);
	   		GameObject marker = Instantiate(prefab, pos, item.transform.rotation);
	   		marker.transform.parent = transform;
	   		marker.layer=6;
	   		marker.tag="ItemMarker";
	   	}
   	}
	oldItemUpdateRequest = itemUpdateRequest;
   	
   }
}
