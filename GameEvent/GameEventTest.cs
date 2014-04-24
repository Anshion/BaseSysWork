using UnityEngine;
using System.Collections;

public class GameEventTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//添加死亡监听
		GameEventDispatcher.AddListener(GameEvents.PlayerDead,  new OnGameEvent(OnPlayerDead), false);	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			//派发死亡事件
			GameEventDispatcher.Dispatch(this, new PlayerDeadEvent());
		}
	}

	//执行死亡逻辑
	void OnPlayerDead(object sender, GameEvent e)
	{
		Debug.Log("OnPlayerDead :  sender = " + sender.ToString());
	}
}
