using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour {

	public Sprite DirtTex;
	public Sprite TilledTex;
	public Sprite SproutTex;
	public Sprite PumpkinTex;

	private bool active;

	private Transform playerTransform;
	private Transform myTransform;

	private string myState;
	private bool isActive;
	private float timeLeft;

	int myGrid_x;
	int myGrid_y;

	void Till()
	{
		if (isActive == true && myState == "Dirt")
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = TilledTex;
			myState = "Tilled";
		}
	}
	void Plant()
	{
		if (isActive == true && myState == "Tilled")
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = SproutTex;
			GameObject.Find("Player").GetComponent<InventoryController>().RemoveInventory("Seed", 1);
			myState = "Sprout";
		}
	}
	void Water()
	{
		if (isActive == true && myState == "Sprout")
		{

		}
	}

	bool PlayerOverTile()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		int playerGrid_x = Mathf.RoundToInt(((playerTransform.position.x)/ .32f));
		int playerGrid_y = Mathf.RoundToInt(((playerTransform.position.y - .20f) / .32f));

		if (playerGrid_x == myGrid_x && playerGrid_y == myGrid_y)
			return true;

		else
			return false;
	}

	void Start () 
	{
		myTransform = this.transform;
		myGrid_x = Mathf.RoundToInt(((myTransform.position.x) / .32f));
		myGrid_y = Mathf.RoundToInt(((myTransform.position.y) / .32f));
		myState = "Dirt";
		timeLeft = 5f;

	}

	void Update()
	{
		string activeItem = InventoryController.ActiveItem;

		if (PlayerOverTile())
		{
			if (activeItem == "Hoe" && myState == "Dirt")
			{
				isActive = true;
				GetComponent<SpriteRenderer> ().color = new Color (.9f, .75f, .75f);
			}
			else if (activeItem == "Seed" && myState == "Tilled")
			{
				isActive = true;
				GetComponent<SpriteRenderer> ().color = new Color (.75f, .9f, .75f);
			}
			else if (activeItem == "Water" && myState == "Sprout")
			{
				isActive = true;
				GetComponent<SpriteRenderer> ().color = new Color (.65f, .75f, 1f);
			}
			else
			{
				isActive = false;
				GetComponent<SpriteRenderer>().color = new Color(1,1,1);
			}
		}
		else
		{
			isActive = false;
			GetComponent<SpriteRenderer>().color = new Color(1,1,1);
		}

		if (myState == "Sprout")
		{
			timeLeft -= Time.deltaTime;
			{
				if (timeLeft < 0)
				{
					myState = "Dirt";
					gameObject.GetComponent<SpriteRenderer>().sprite = DirtTex;
					GameObject pumpkin = (GameObject)Instantiate(Resources.Load("Pumpkin"));
					pumpkin.transform.position = this.transform.position;
				}
			}
		}
			
	}
}
