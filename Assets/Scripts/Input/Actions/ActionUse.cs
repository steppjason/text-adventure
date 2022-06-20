using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Action/Use")]
public class ActionUse : InputAction {
	public override void DoAction(GameController _gameController, string[] input) {
		_gameController.itemController.UseItem(input);
	}
}
