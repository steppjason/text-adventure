using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Reponse/Room Response")]
public class RoomResponse : ActionResponse {

	public Room newRoom;

	public override bool DoActionResponse(GameController gameController) {
		if(gameController.roomNavigation.currentRoom.roomName == requiredString) {
			gameController.roomNavigation.currentRoom = newRoom;
			gameController.DisplayRoomText();
			return true;
		}
		return false;
	}

}
