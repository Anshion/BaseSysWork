using UnityEngine;
using System.Collections;

public class StateMachineTest : MonoBehaviour {
	Player player;
	// Use this for initialization
	void Start () {
		player = new Player();
		player.SetSate(new WalkState());
	}
	
	// Update is called once per frame
	void Update () {

		//根据不同的状态执行不同的状态逻辑
		player.state.Logic();
	}
}
