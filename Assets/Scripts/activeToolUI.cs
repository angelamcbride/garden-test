using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeToolUI : MonoBehaviour {

	public RectTransform rt;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		int activeSlot = InventoryController.ActiveSlot;

		float newYPos = 4 + activeSlot * -69;
		Vector3 newVect = new Vector3 (0f, newYPos,0);
		rt.anchoredPosition = newVect;

	}
}
