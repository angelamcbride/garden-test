using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			string type = tag;
			GameObject.Find("Player").GetComponent<InventoryController>().AddInventory(type, 1);
			gameObject.SetActive (false);
		}
	}
				
}
