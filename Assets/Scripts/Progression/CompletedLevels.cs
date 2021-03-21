using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CompletedLevels : MonoBehaviour
{

    public static CompletedLevels instance = null;
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    public int completed_levels = 0;

    public void CompletedLevel()
    {
        completed_levels += 1;

    }

    public int CheckCompleted()
    {
        return completed_levels;
    }

    //Saving system

    public void ResetState()
    {
        completed_levels = 0;
    }

    public object CaptureState()
    {
        return new SaveData
        {
            completed_levels = completed_levels
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        completed_levels = saveData.completed_levels;
    }

    [Serializable]
    private struct SaveData
    {
        public int completed_levels;
    }


}
