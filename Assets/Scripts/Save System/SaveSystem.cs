using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.PackageManager;

public class SaveSystem : MonoBehaviour
{
    public string data_path => $"{Application.persistentDataPath}/save.txt";

    public static SaveSystem instance = null;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    [ContextMenu("Save")]
    public void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }
    public void NewGame()
    {
        var state = ResetSaveFile();
        CaptureState(state);
        SaveFile(state);
        RestoreState(state);
    }
    [ContextMenu("Load")]
    public void Load()
    {
        var state = LoadFile();
        RestoreState(state);      
    }
    void SaveFile(object state)
    {
        using(var stream = File.Open(data_path, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }       
    }
    private Dictionary<string, object> LoadFile()
    {
        if(!File.Exists(data_path))
        {
            return new Dictionary<string, object>();
        }
        using (FileStream stream = File.Open(data_path, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }

    }
    private Dictionary<string, object> ResetSaveFile()
    {
        foreach (var saveable in FindObjectsOfType<Saveable>())
        {
            saveable.ResetState();
        }
        return new Dictionary<string, object>();
    }
    private void CaptureState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<Saveable>())
        {
            state[saveable.Id] = saveable.CaptureState();
        }
    }
    public void RestoreState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<Saveable>())
        {
            if (state.TryGetValue(saveable.Id, out object value))
            {
                saveable.RestoreState(value);
            }
        }

    }

}
