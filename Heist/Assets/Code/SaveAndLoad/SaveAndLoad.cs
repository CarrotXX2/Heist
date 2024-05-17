using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;


public class SaveAndLoad : MonoBehaviour
{
    public SaveDataModel loadItInHere;
    public Transform character;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SaveData()
    {
        SaveDataModel model = new SaveDataModel();
        model.positie = transform.position;
        model.rotatie = transform.rotation;
        
      


        string json = JsonUtility.ToJson(model);

        string bestandsPad = Application.persistentDataPath + "/Savedata.json";
        print(bestandsPad);
        File.WriteAllText(bestandsPad, json);
    }
    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            loadItInHere = JsonUtility.FromJson<SaveDataModel>(json);
            character.transform.position = loadItInHere.positie;
            character.transform.rotation = loadItInHere.rotatie;
           

        }

    }

    public class SaveDataModel
    {
        public Vector3 positie;
        public Quaternion rotatie;
        public int score;
        


    }
}
