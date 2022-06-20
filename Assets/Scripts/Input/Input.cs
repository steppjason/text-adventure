using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Input : MonoBehaviour {

	public TMP_InputField inputField;

	GameController _gameController;

	void Awake() {
		_gameController = GetComponent<GameController>();
		inputField.onEndEdit.AddListener(GetInput);
	}

	void GetInput(string input) {
		_gameController.AddLog(input);

		input = input.ToLower();
		char[] delimiter = { ' ' };
		string[] inputWords = input.Split(delimiter);

		for (int i = 0; i < _gameController.actions.Length; i++) {

			InputAction action = _gameController.actions[i];

			if (action.keyword == inputWords[0]) {
				action.DoAction(_gameController, inputWords);
			}

		}

		_gameController.DisplayLog();
		ResetInputField();
	}

	void ResetInputField() {
		inputField.ActivateInputField();
		inputField.text = null;
	}
}
