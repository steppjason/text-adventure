using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Action/Examine")]
public class ActionExamine : InputAction {

	public override void DoAction(GameController _gameController, string[] input) {
		string examineResponse = _gameController.CheckVerb(_gameController.itemController.examineDictionary, input[0], input[1]);
		Debug.Log(examineResponse);
		_gameController.AddLog(examineResponse);
	}

}
