using System;
using System.Collections.Generic;


public static class EventManager {

    private static Dictionary<Type, _EventManager> managers;

    public static void AddListener<T>(Action<T> listener) where T : EventInfo
    {
        Type eventType = typeof(T);

        if (managers == null)
        {
            managers = new Dictionary<Type, _EventManager>();
        }

        if (managers.ContainsKey(eventType) == false || managers[eventType] == null)
        {
            managers[eventType] = new _EventManager<T>();
        }

        ((_EventManager<T>)managers[eventType]).Add(listener);

    }

    public static void RemoveListener<T>(Action<T> listener) where T : EventInfo
    {
        Type eventType = typeof(T);
        if (managers == null || managers[eventType] == null)
        {
            return;
        }
        ((_EventManager<T>)managers[eventType]).Remove(listener);
    }

    public static void FireEvent<T>(T eventInfo) where T : EventInfo
    {
        Type eventType = typeof(T);
        if (managers == null || managers[eventType] == null)
        {
            return;
        }
        ((_EventManager<T>)managers[eventType]).Fire(eventInfo);
    }
        
    private abstract class _EventManager { };
    private class _EventManager<T> : _EventManager where T : EventInfo
    {
        private event Action<T> listeners;

        public void Add(Action<T> listener)
        {
            listeners += listener;
        }

        public void Remove(Action<T> listener)
        {
            listeners -= listener;
        }

        public void Fire(T eventInfo)
        {
            listeners(eventInfo);
        }
    }
}
