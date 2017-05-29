using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	GameObject[] gardenTiles;

	void Start()
	{
		gardenTiles = GameObject.FindGameObjectsWithTag("FarmSoil");
	}

	public void Update()
	{
		if (Input.GetButtonDown("Action1"))
		{
			string activeItem = InventoryController.ActiveItem;
			if (activeItem == "Seed")
			{
				foreach (GameObject tile in gardenTiles)
				{
					tile.SendMessage ("Plant");
				}
			}

			if (activeItem == "Hoe")
			{
				foreach (GameObject tile in gardenTiles)
				{
					tile.SendMessage ("Till");
				}
			}

			if (activeItem == "Water")
			{
				foreach (GameObject tile in gardenTiles)
				{
					tile.SendMessage ("Water");
				}
			}
	
		}
	}
		
}
