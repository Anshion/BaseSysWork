using UnityEngine;
using System.Collections;

public class AvatarInput : MonoBehaviour {
	public Avatar avatar;

	private bool jump;
	private bool attack;

	private float attackTime;

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
		if(Time.time - attackTime > avatar.attributes.AttackInputValidTime) attack = false;
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
		set{
			if(value)
			{
				attackTime = Time.time;
				attack = value;
			}


		}
	}
}
