using UnityEngine;
using System.Collections;

public class AvatarInput : MonoBehaviour {
	public Avatar avatar;

	private bool jump;
	
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
	}

	protected virtual void OnInputProcessed()
	{

	}

	public bool Jump
	{
		get{return this.jump;}
		set{jump = value;}
	}
}
