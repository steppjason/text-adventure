using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

	[HideInInspector] public RoomNavigation roomNavigation;
	[HideInInspector] public List<string> roomInteractions = new List<string>();

	//public Text displayText;
	public TMP_Text displayText;
	public InputAction[] actions;

	List<string> _log = new List<string>();

	void Awake() {
		roomNavigation = GetComponent<RoomNavigation>();
	}

	void Start() {
		DisplayRoomText();
		DisplayLog();
	}

	public void DisplayRoomText() {

		ClearRoom();

		GetRoom();

		string roomDescription = roomNavigation.currentRoom.description + "\n";
		string joinedRoomInteractions = string.Join("\n", roomInteractions.ToArray());

		string combinedText = roomDescription + joinedRoomInteractions;
		AddLog(combinedText);

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
	}

	void ClearRoom() {
		roomInteractions.Clear();
		roomNavigation.ClearExits();
	}
}
