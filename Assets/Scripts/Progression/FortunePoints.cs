using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortunePoints : MonoBehaviour, ISaveable
{
    [SerializeField] int fortune_points;
    public object CaptureState()
    {
        return new SaveData
        {
            fortune_points = fortune_points
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        fortune_points = saveData.fortune_points;
    }

    [Serializable]
    private struct SaveData
    {
        public int fortune_points;
    }
}
