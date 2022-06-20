using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Action/Inventory")]
public class ActionInventory : InputAction {
	public override void DoAction(GameController _gameController, string[] input) {
		_gameController.itemController.GetInventory();
	}
}
