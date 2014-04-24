using UnityEngine;
using System.Collections;

public class PlayerDeadEvent : GameEvent {

	public PlayerDeadEvent()
	{
		base.Name = GameEvents.PlayerDead;
	}
}
