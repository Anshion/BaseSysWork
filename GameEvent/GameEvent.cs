using System;
/// <summary>
/// 事件的基类
/// </summary>
public class GameEvent
{
    protected string name = "Default";

    public GameEvent()
    {
    }

    public GameEvent(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
}

