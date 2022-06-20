using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	[HideInInspector] public List<string> roomItems = new List<string>();
	public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
	public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

	List<string> inventoryItems = new List<string>();
	GameController _gameController;

	void Awake() {
		_gameController = GetComponent<GameController>();
	}

	public string GetItems(Room currentRoom, int index) {
		Item item = currentRoom.items[index];

		if (!inventoryItems.Contains(item.itemName)) {
			roomItems.Add(item.itemName);
			return item.description;
		}

		return null;
	}

	public void GetInventory(){
		_gameController.AddLog("You look in your inventory:");
		for (int i = 0; i < inventoryItems.Count; i++){
			_gameController.AddLog(inventoryItems[i]);
		}
	}

	public void ClearCollection() {
		examineDictionary.Clear();
		takeDictionary.Clear();
		roomItems.Clear();
	}

	public Dictionary<string, string> Take(string[] input) {
		string item = input[1];

		if (roomItems.Contains(item)) {
			inventoryItems.Add(item);
			roomItems.Remove(item);
			return takeDictionary;
		} else {
			_gameController.AddLog("Can't do that.");
			return null;
		}

	}

}
