using UnityEngine;
using System.Collections;

public class AvatarInput : MonoBehaviour {
	public Avatar avatar;

	private bool jump;
	private bool attack;
	
	public void UpdateInput()
	{
		OnUpdateInput();
	}
	
	protected virtual void OnUpdateInput()
	{

	}

	public void InputProcessed()
	{
		Jump = false;
		Attack = false;
	}

	protected virtual void OnInputProcessed()
	{

	}

	public bool Jump
	{
		get{return this.jump;}
		set{jump = value;}
	}

	public bool Attack
	{
		get{return this.attack;}
		set{attack = value;}
	}
}
