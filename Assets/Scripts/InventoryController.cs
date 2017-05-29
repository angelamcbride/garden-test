using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public static string ActiveItem;
	public static int ActiveSlot;

	public Text Slot1;
	public Text Slot2;
	public Text Slot3;
	public Text Slot4;

	private List<Text> SlotList = new List<Text>();

	private Dictionary<string, int> InvDict = new Dictionary<string, int>();  //(item, quantity)
	private List<string> InvList = new List<string>(); //used for organizing invDict

	//----------------------------------------Add Inventory-------------------------------------------------//

	public void AddInventory(string type, int amount)
	{
		if (InvDict.ContainsKey (type)) //if item type in inventory
		{
			InvDict[type] = InvDict[type]+amount;  //increase quantity
		} 
		else
		{
			InvDict.Add(type, amount);  //Add to new item to inventory with amount
			InvList.Add(type);
		}
		updateInv ();
	}
		

	//----------------------------------------Remove Inventory-------------------------------------------------//

	public bool RemoveInventory(string type, int amount)  //if player doesn't have the inventory asked for, returns false.
	{
		if (InvDict.ContainsKey (type)  && InvDict[type] >= amount)
		{
			InvDict[type] = InvDict[type]-amount;

			if (InvDict [type] == 0) //remove zero quantity items
			{
				InvDict.Remove (type);
				InvList.Remove (type);
			}

			updateInv ();
			return true;
		} 
		else
		{
			return false;
		}
	}
	//--------------------------------------Update Inventory Display-----------------------------------------------------//

	void updateInv()
	{
		
		for (int i = 0; i < SlotList.Count; i++)  //cleanup UI
		{
			SlotList [i].text = "";
		}
		ActiveItem = "NONE";


		if (InvList.Count > 0) //inventory contains items
		{
			for (int i = 0; i < InvList.Count; i++) //display our updated inventory
			{
				string item = InvList [i];
				int value = InvDict [item];
				SlotList [i].text = item.ToUpper () + "\n     " + value.ToString ();
			}

			if (InvList.Count > ActiveSlot) //If an item exists in the active slot, assign it as active item
			{
				ActiveItem = InvList [ActiveSlot];
			}
			else
			{
				InventoryController.ActiveItem = "NONE";
			}

		} 
	}

	//--------------------------------------------------------------------------------------------------------//

	void Start () 
	{
		SlotList.Add (Slot1);
		SlotList.Add (Slot2);
		SlotList.Add (Slot3);
		SlotList.Add (Slot4);
		ActiveSlot = 0;
		InventoryController.ActiveItem = "NONE";
	}

	void Update()
	{
		float scrollInput = Input.GetAxis ("Mouse ScrollWheel");

		if (scrollInput > 0f)
		{
			ActiveSlot--;
		}
		if (scrollInput < 0f)
		{
			ActiveSlot++;
		}

		ActiveSlot = Mathf.Clamp(ActiveSlot,0,3);

		if (InvList.Count > ActiveSlot) //If an item exists in the active slot, assign it as active item
		{
			ActiveItem = InvList [ActiveSlot];
		} 
		else
		{
			InventoryController.ActiveItem = "NONE";
		}

	}
		
}
