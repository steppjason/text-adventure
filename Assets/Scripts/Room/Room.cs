using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
	public string roomName;
	[TextArea]
	public string description;
	public Exit[] exits;
	public Item[] items;

}
