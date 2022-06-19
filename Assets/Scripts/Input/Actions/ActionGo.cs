using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Action/Go")]
public class ActionGo : InputAction {

	public override void DoAction(GameController _gameController, string[] input) {
		_gameController.roomNavigation.ChangeRoom(input[1]);
	}

}
