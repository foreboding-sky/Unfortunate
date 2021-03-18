using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortunePoints : MonoBehaviour, ISaveable
{
    public static FortunePoints instance = null;
    void Start ()
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
    [SerializeField] int fortune_points;
    public object CaptureState()
    {
        return new SaveData
        {
            fortune_points = fortune_points
        };
    }
    public bool CanBuy(int points)
    {
        if (fortune_points >= points && fortune_points >=0 && points >= 0)
        {
            fortune_points -= points;
            return true;
        }
        else return false;
    }
    public void AddPoints(int points)
    {
        fortune_points += points;
    }
    public int CheckPoints()
    {
        return fortune_points;
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
