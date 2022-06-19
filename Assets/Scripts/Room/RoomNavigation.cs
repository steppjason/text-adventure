using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

	public Room currentRoom;

	Dictionary<string, Room> exits = new Dictionary<string, Room>();
	GameController _gameController;

	void Awake() {
		_gameController = GetComponent<GameController>();
	}

	public void AddExitInteractions() {
		for (int i = 0; i < currentRoom.exits.Length; i++) {
			_gameController.roomInteractions.Add(currentRoom.exits[i].description);
			exits.Add(currentRoom.exits[i].key, currentRoom.exits[i].room);
		}
	}


	public void ClearExits() {
		exits.Clear();
	}	

	public void ChangeRoom(string keyword){
		if(exits.ContainsKey(keyword)){
			currentRoom = exits[keyword];
			_gameController.AddLog("You go to " + keyword);
			_gameController.DisplayRoomText();
		} else {
			_gameController.AddLog("You can't go there");
		}
	}

}
