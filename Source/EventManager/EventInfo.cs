using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventInfo
{
    protected string eventDescription;
    public string EventDescription
    {
        get
        {
            return eventDescription;
        }
    }
}

public class DebugEventInfo : EventInfo
{
    public DebugEventInfo()
    {
        eventDescription = "DebugEventInfo";
    }
}
