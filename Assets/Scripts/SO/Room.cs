using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdvencture/Room")]
public class Room : ScriptableObject
{
	public string name;
	[TextArea]
	public string description;
	public Exit[] exits;

}
