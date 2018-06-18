# EventManager

This is a simple system to fire/listen to events from anywhere in your code.

## Usage

Each event needs to subclass from `EventInfo`. An example is provided in `EventInfo.cs` with `DebugEventInfo`.
Anywhere in the code, you can listen to this event by defining a handler function and registering it to the `EventManager`.
Anywhere in the code, you can fire the event by creating a new instance of the respective `EventInfo` subclass and 
firing the event with the `EventManager`.

### Firing the event
```csharp
public void SomeFunction(){
    EventManager.FireEvent(new DebugEventInfo());
}
<<<<<<< HEAD
```

### Starting/Stopping to listen
```csharp
=======

### Starting/Stopping to listen
```csharp

>>>>>>> master
public void Start()
{
    // You can do this anywhere.
    EventManager.AddListener<DebugEventInfo>(OnDebugEventInfo);
}

// This function can be called as you see fit but needs to take a single parameter of type `DebugEventInfo`.
public void OnDebugEventInfo(DebugEventInfo debugEventInfo)
{
    Debug.Log("Received debugEventInfo.");
}

public void OnDestroy()
{
    // Just to make sure, we can also stop listening.
    EventManager.RemoveListener<DebugEventInfo>(OnDebugEventInfo);
}
```