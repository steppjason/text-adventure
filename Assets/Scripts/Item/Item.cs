using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Item")]
public class Item : ScriptableObject {
	public string itemName;
	[TextArea(20, 99)]
	public string description;
	public Interaction[] interactions;
}
