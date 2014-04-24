using UnityEngine;
using System.Collections;

public class Player  {
	public State state;

	public Player()
	{
//		GameEventDispatcher.AddListener(GameEvents.PlayerDead, new OnGameEvent(OnPlayerDead));
	}

	public void SetSate(State newState)
	{
		state = newState;
		state.Initialize();
	}

	public void OnPlayerDead(object sender, GameEvent e)
	{
		SetSate(new DeadState());
	}
}
