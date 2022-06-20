using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	[HideInInspector] public List<string> roomItems = new List<string>();
	public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
	public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
	public List<Item> useableItems = new List<Item>();

	List<string> inventoryItems = new List<string>();
	Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
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

	public void GetInventory() {
		_gameController.AddLog("You look in your inventory:");
		for (int i = 0; i < inventoryItems.Count; i++) {
			_gameController.AddLog(inventoryItems[i]);
		}
	}

	public void GetActionResponses() {
		for (int i = 0; i < inventoryItems.Count; i++) {
			string item = inventoryItems[i];

			Item useableItem = GetUseableItems(item);
			if (useableItem == null)
				continue;

			for (int j = 0; j < useableItem.interactions.Length; j++) {
				Interaction interaction = useableItem.interactions[j];
				if (interaction.actionResponse == null)
					continue;

				if (!useDictionary.ContainsKey(item)) {
					useDictionary.Add(item, interaction.actionResponse);
				}
			}
		}
	}

	Item GetUseableItems(string itemName) {
		for (int i = 0; i < useableItems.Count; i++) {
			if (useableItems[i].itemName == itemName) {
				return useableItems[i];
			}
		}
		return null;
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
			GetActionResponses();
			roomItems.Remove(item);
			return takeDictionary;
		} else {
			_gameController.AddLog("Can't do that.");
			return null;
		}

	}

	public void UseItem(string[] input) {
		string item = input[1];

		if (inventoryItems.Contains(item)) {
			if (useDictionary.ContainsKey(item)) {
				bool actionResult = useDictionary[item].DoActionResponse(_gameController);
				if (!actionResult) {
					_gameController.AddLog("Nothing happens.");
				}
			} else {
				_gameController.AddLog("You can't use that.");
			}
		} else {
			_gameController.AddLog("There is no " + item + " to use.");
		}
	}

}
