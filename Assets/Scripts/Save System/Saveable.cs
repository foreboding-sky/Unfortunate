using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saveable : MonoBehaviour
{
    [SerializeField] string id = string.Empty;
    public string Id => id;

    [ContextMenu("Generate Id")]
    private void GenerateId() => id = Guid.NewGuid().ToString();

    public object CaptureState()
    {
        var state = new Dictionary<string, object>();

        foreach(var saveable in GetComponents<ISaveable>())
        {
            state[saveable.GetType().ToString()] = saveable.CaptureState();
        }
        return state;
    }
    public void RestoreState(object state)
    {
        var state_dictionary = (Dictionary<string, object>)state;

        foreach (var saveable in GetComponents<ISaveable>())
        {
            string type_name = saveable.GetType().ToString();

            if(state_dictionary.TryGetValue(type_name, out object value))
            {
                saveable.RestoreState(value);
            }
            
        }

    }
}
