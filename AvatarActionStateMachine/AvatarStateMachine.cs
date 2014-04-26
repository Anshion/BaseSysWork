using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Avatar))]
public class AvatarStateMachine : MonoBehaviour {
	public Avatar avatar;

	public const int MaxActionNum = 0x2f;
	public const int MaxEventNum = 0x2f;
	/// <summary>
	/// 玩家事件数组
	/// </summary>
	protected IAction[] actions;
	/// <summary>
	/// 玩家事件数组
	/// </summary>
	private List<Transition>[] eventMatrix;

	private IAction currentAction;
	private ActionCode prevActionState = ActionCode.NONE;
	private ActionCode nextActionState = ActionCode.NONE;

	public void InitStateMachine()
	{
		this.avatar = this.GetComponent<Avatar>();
		this.eventMatrix = new List<Transition>[MaxEventNum];
		for(int i = 0; i < MaxEventNum; i++)
		{
			this.eventMatrix[i] = new List<Transition>(MaxEventNum);
		}
		this.InitEventMatrix();
		this.actions = new IAction[MaxActionNum];
		this.InitActions();
		this.currentAction = this.actions[0];
		this.currentAction.GetIn(new object[0]);
	}

	public void UpdateStateMachine()
	{
		this.currentAction.Update(Time.fixedDeltaTime);
		if(CheckEvent())
		{
			this.currentAction.Update(Time.fixedDeltaTime);
		}
	}

	public void AddAction(IAction action)
	{
		this.actions[(int) action.GetState()] = action;
	}

	public bool CanSwitchTo(ActionCode toState)
	{
		return this.actions[(int) toState].CanGetIn();
	}

	public IAction GetCurAction()
	{
		return this.currentAction;
	}

	public ActionCode GetCurState()
	{
		if(currentAction == null){
			return ActionCode.NONE;
		}
		return currentAction.GetState();
	}
	

	protected virtual void InitActions()
	{

	}


	public void SwitchTo(ActionCode toState)
	{
		this.SwitchTo(toState, null);
	}

	public void SwitchTo(ActionCode toState, params object[] list)
	{
		if(this.actions == null){
			Debug.Log("actions is null");
		}else{
			IAction action = this.actions[(int) toState];
			this.nextActionState = action.GetState();
			currentAction.GetOut();
			this.prevActionState = currentAction.GetState();
			currentAction = action;
			action.GetIn(list);
		}
	}
	
	protected virtual void InitEventMatrix()
	{

	}

	protected void AddEventTranstion(ActionCode fromAction, ActionCode toAction, IEvent byEvent)
	{
		byEvent.SetAvatarRef(avatar);
		eventMatrix[(int) fromAction].Add(new Transition(toAction, byEvent));
	}

	private bool CheckEvent()
	{
		int state = (int)currentAction.GetState();
		if(state < this.eventMatrix.Length)
		{
			for(int i = 0; i < eventMatrix[state].Count; i++)
			{
				Transition transition = eventMatrix[state][i];
				if(transition.byEvent.Check())
				{
					SwitchTo(transition.toAction);
					return true;
				}
			}
		}

		return false;
	}




//    public void SwitchTo(ActionCode toState, params object[] list)
//    {
//        if (this.actions == null)
//        {
//            Debug.Log("actions is null");
//        }
//        else
//        {
//            IAction action = this.actions[(int) toState];
//            this.nextActionState = action.GetState();
//            this.currentAction.GetOut();
//            this.prevActionState = this.currentAction.GetState();
//            this.currentAction = action;
//            this.nextActionState = ActionCode.NONE;
//            this.currentActionTime = 0f;
//            this.currentAction.GetIn(list);
//            this.prevActionState = ActionCode.NONE;
//            this.avatarChangeStateEvent.CurrentState = this.currentAction;
//            GameEventDispatcher.Dispatch(this, this.avatarChangeStateEvent);
//        }
//    }

//	[StructLayout(LayoutKind.Sequential)]
//	private struct Transition  
//	{
//		public ActionCode toAction;
//		public IEvent byEvent;
//
//		public Transition(ActionCode toAction, IEvent byEvent)
//		{
//			this.toAction = toAction;
//			this.byEvent = byEvent;
//		}
//	}
//	[StructLayout(LayoutKind.Sequential)]
	private struct Transition
	{
		public ActionCode toAction;
		public IEvent byEvent;
		public Transition(ActionCode toAction, IEvent byEvent)
		{
			this.toAction = toAction;
			this.byEvent = byEvent;
		}
	}

}
