using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    
    private Dictionary<string, Action> eventDictionary0;
    private Dictionary<string, Action<object>> eventDictionary1;
    private Dictionary<string, Action<object, object>> eventDictionary2;
    private Dictionary<string, Action<object, object, object>> eventDictionary3;

    private void Awake()
    {
        instance = this;
        SceneManager.sceneUnloaded += ClearListeners;
    }

    public void AddListener(string eventName, Action listener)
    {
        eventDictionary0 ??= new Dictionary<string, Action>();
        if (eventDictionary0.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += listener;
            eventDictionary0[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary0.Add(eventName, thisEvent);
        }
    }

    public void AddListener(string eventName, Action<object> listener)
    {
        eventDictionary1 ??= new Dictionary<string, Action<object>>();

        if (eventDictionary1.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += listener;
            eventDictionary1[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary1.Add(eventName, thisEvent);
        }
    }

    private void ClearListeners(Scene scene)
    {
        eventDictionary0?.Clear();
        eventDictionary1?.Clear();
        eventDictionary2?.Clear();
        eventDictionary3?.Clear();
    }
    
        
    public void AddListener(string eventName, Action<object, object> listener)
    {
        eventDictionary2 ??= new Dictionary<string, Action<object, object>>();

        if (eventDictionary2.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += listener;
            eventDictionary2[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary2.Add(eventName, thisEvent);
        }
    }
        
    public void AddListener(string eventName, Action<object, object, object> listener)
    {
        eventDictionary3 ??= new Dictionary<string, Action<object, object, object>>();

        if (eventDictionary3.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += listener;
            eventDictionary3[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary3.Add(eventName, thisEvent);
        }
    }

    public void RemoveListener(string eventName, Action listener)
    {
        if (!eventDictionary0.TryGetValue(eventName, out var thisEvent)) return;
            
        thisEvent -= listener;
        if (thisEvent == null)
        {
            eventDictionary0.Remove(eventName);
        }
        else
        {
            eventDictionary0[eventName] = thisEvent;
        }
    }

    public void RemoveListener(string eventName, Action<object> listener)
    {
        if (!eventDictionary1.TryGetValue(eventName, out var thisEvent)) return;
            
        thisEvent -= listener;
        if (thisEvent == null)
        {
            eventDictionary1.Remove(eventName);
        }
        else
        {
            eventDictionary1[eventName] = thisEvent;
        }
    }

    public void TriggerEvent(string eventName)
    {
        if (eventDictionary0 == null)
        {
            Debug.LogWarning("[EventManager] TriggerEvent:: Event couldn't be triggered because there are no listeners");
            return;
        }

        if (eventDictionary0.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public void TriggerEvent(string eventName, object arg1)
    {
        if (eventDictionary1 == null)
        {
            Debug.LogWarning("[EventManager] TriggerEvent:: Event couldn't be triggered because there are no listeners");
            return;
        }

        if (eventDictionary1.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent.Invoke(arg1);
        }
    }
        
    public void TriggerEvent(string eventName, object arg1, object arg2)
    {
        if (eventDictionary2 == null)
        {
            Debug.LogWarning("[EventManager] TriggerEvent:: Event couldn't be triggered because there are no listeners");
            return;
        }

        if (eventDictionary2.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent.Invoke(arg1, arg2);
        }
    }
        
    public void TriggerEvent(string eventName, object arg1, object arg2, object arg3)
    {
        if (eventDictionary3 == null)
        {
            Debug.LogWarning("[EventManager] TriggerEvent:: Event couldn't be triggered because there are no listeners");
            return;
        }

        if (eventDictionary3.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent.Invoke(arg1, arg2, arg3);
        }
    }
}

public class EventNames
{
    public static readonly string EarnCoin = "EarnCoin";
    public static readonly string UpdateProductCount = "UpdateProductCount";
}