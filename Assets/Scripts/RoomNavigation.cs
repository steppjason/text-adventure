using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
	public Room currentRoom;

	GameController _gameController;

	void Awake()
	{
		_gameController = GetComponent<GameController>();
	}

	public void UnpackExitRooms()
	{
		for (int i = 0; i < currentRoom.exits.Length; i++)
		{
			_gameController.roomInteractions.Add(currentRoom.exits[i].description);
		}
	}
}
