using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    public SaveDataModel loadItInHere;
    public Transform character;

    void Start()
    {
        // Optionally, you can call LoadData at the start to load data automatically when the game starts.
        // LoadData();
    }

    public void SaveData()
    {
        SaveDataModel model = new SaveDataModel();
        model.positie = character.position; // Use character's position
        model.rotatie = character.rotation; // Use character's rotation

        string json = JsonUtility.ToJson(model);
        string bestandsPad = Application.persistentDataPath + "/Heist.json";

        Debug.Log("Saving to: " + bestandsPad);
        Debug.Log("JSON: " + json);

        File.WriteAllText(bestandsPad, json);
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/Heist.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            loadItInHere = JsonUtility.FromJson<SaveDataModel>(json);

            Debug.Log("Loaded JSON: " + json);

            if (character != null)
            {
                character.position = loadItInHere.positie;
                character.rotation = loadItInHere.rotatie;
            }
            else
            {
                Debug.LogError("Character transform is not assigned!");
            }
        }
        else
        {
            Debug.LogError("Save file not found at: " + filePath);
        }
    }

    [System.Serializable]
    public class SaveDataModel
    {
        public Vector3 positie;
        public Quaternion rotatie;
    }
}
