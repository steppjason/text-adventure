using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

	[HideInInspector] public RoomNavigation roomNavigation;
	[HideInInspector] public ItemController itemController;
	[HideInInspector] public List<string> roomItemDescriptions = new List<string>();

	//public Text displayText;
	public TMP_Text displayText;
	public InputAction[] actions;

	List<string> _log = new List<string>();

	void Awake() {
		roomNavigation = GetComponent<RoomNavigation>();
		itemController = GetComponent<ItemController>();
	}

	void Start() {
		DisplayRoomText();
		DisplayLog();
	}

	public void DisplayRoomText() {
		ClearRoom();
		GetRoom();

		string roomDescription = roomNavigation.currentRoom.description + "\n";
		string joinedroomItemDescriptions = string.Join("\n", roomItemDescriptions.ToArray());

		string combinedText = roomDescription + joinedroomItemDescriptions;
		AddLog(combinedText);
		DisplayLog();
	}

	public void AddLog(string str) {
		_log.Add(str + "\n");
	}

	public void DisplayLog() {
		string joinedLog = string.Join("\n", _log.ToArray());
		displayText.text = joinedLog;
	}

	void GetRoom() {
		roomNavigation.AddExitInteractions();
		GetItems(roomNavigation.currentRoom);
	}

	void GetItems(Room currentRoom) {
		for (int i = 0; i < currentRoom.items.Length; i++) {
			string itemDescription = itemController.GetItems(currentRoom, i);

			if (itemDescription != null) {
				roomItemDescriptions.Add(itemDescription);
			}

			Item item = currentRoom.items[i];
			for (int j = 0; j < item.interactions.Length; j++) {
				Interaction interaction = item.interactions[j];
				
				if (interaction.inputAction.keyword == "examine") {
					itemController.examineDictionary.Add(item.itemName, interaction.response);
				}

				if (interaction.inputAction.keyword == "take") {
					itemController.takeDictionary.Add(item.itemName, interaction.response);
				}

			}
		}
	}

	public string CheckVerb(Dictionary<string, string> verbs, string verb, string itemName) {
		if(verbs.ContainsKey(itemName)){
			return verbs[itemName];
		}

		return "Can\'t do that.";
	}

	void ClearRoom() {
		roomItemDescriptions.Clear();
		roomNavigation.ClearExits();
		itemController.ClearCollection();
	}
}
