using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GameEventDispatcher
{
    private static bool dispatching = false;
    private static Dictionary<string, List<OnGameEvent>> globalEventCallbacks = new Dictionary<string, List<OnGameEvent>>();
    private static List<KeyValuePair<string, OnGameEvent>> purge = new List<KeyValuePair<string, OnGameEvent>>();
    private static Dictionary<string, List<OnGameEvent>> sceneEventCallbacks = new Dictionary<string, List<OnGameEvent>>();

	/// <summary>
	/// 添加一个事件监听回调
	/// </summary>
	/// <param name="evt">Evt.</param>
	/// <param name="callback">Callback.</param>
	/// <param name="scopeGlobal">If set to <c>true</c> scope global.</param>
    public static void AddListener(string evt, OnGameEvent callback, bool scopeGlobal = false)
    {
        if (!scopeGlobal)
        {
            if (!sceneEventCallbacks.ContainsKey(evt))
            {
                sceneEventCallbacks.Add(evt, new List<OnGameEvent>());
            }
            if (!sceneEventCallbacks[evt].Contains(callback))
            {
                sceneEventCallbacks[evt].Add(callback);
            }
        }
        else
        {
            if (!globalEventCallbacks.ContainsKey(evt))
            {
                globalEventCallbacks.Add(evt, new List<OnGameEvent>());
            }
            if (!globalEventCallbacks[evt].Contains(callback))
            {
                globalEventCallbacks[evt].Add(callback);
            }
        }
    }

	/// <summary>
	/// 清楚所有监听事件
	/// </summary>
    public static void ClearSceneListeners()
    {
        sceneEventCallbacks.Clear();
    }

	/// <summary>
	/// 派发一个事件出去，调用该事件监听者的回调方法
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="evt">Evt.</param>
    public static void Dispatch(object sender, GameEvent evt)
    {
        dispatching = true;
        string name = evt.Name;
        if (sceneEventCallbacks.ContainsKey(name))
        {
            for (int i = 0; i < sceneEventCallbacks[name].Count; i++)
            {
                sceneEventCallbacks[name][i](sender, evt);
            }
        }
        if (globalEventCallbacks.ContainsKey(name))
        {
            for (int j = 0; j < globalEventCallbacks[name].Count; j++)
            {
                globalEventCallbacks[name][j](sender, evt);
            }
        }
        if (purge.Count != 0)
        {
            foreach (KeyValuePair<string, OnGameEvent> pair in purge)
            {
                if (sceneEventCallbacks.ContainsKey(pair.Key))
                {
                    sceneEventCallbacks[pair.Key].Remove(pair.Value);
                }
                if (globalEventCallbacks.ContainsKey(pair.Key))
                {
                    globalEventCallbacks[pair.Key].Remove(pair.Value);
                }
            }
            purge.Clear();
        }
        dispatching = false;
    }

    public static void RemoveListener(string evtName, OnGameEvent callback)
    {
        if (!dispatching)
        {
            if (sceneEventCallbacks.ContainsKey(evtName))
            {
                sceneEventCallbacks[evtName].Remove(callback);
            }
            if (globalEventCallbacks.ContainsKey(evtName))
            {
                globalEventCallbacks[evtName].Remove(callback);
            }
        }
        else
        {
            purge.Add(new KeyValuePair<string, OnGameEvent>(evtName, callback));
        }
    }

    private static void RemoveListenerNow(string evtName, OnGameEvent callback)
    {
        if (sceneEventCallbacks.ContainsKey(evtName))
        {
            sceneEventCallbacks[evtName].Remove(callback);
        }
        if (globalEventCallbacks.ContainsKey(evtName))
        {
            globalEventCallbacks[evtName].Remove(callback);
        }
    }
}

