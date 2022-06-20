using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Actions/Take")]
public class ActionTake : InputAction {

	public override void DoAction(GameController _gameController, string[] input) {
		Dictionary<string, string> takeDictionary = _gameController.itemController.Take(input);
		if(takeDictionary != null) {
			_gameController.AddLog(_gameController.CheckVerb(takeDictionary, input[0], input[1]));
		}
	}

}
