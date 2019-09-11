using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PositionSaver : MonoBehaviour
{

    public Vector3 lastPosition = Vector3.zero;
    public Quaternion lastRotation = Quaternion.identity;
    private Transform thisTransform = null;

    void SaveObject() {

        //Get position and rotation data

         //Create outputpath
         string outputPath = Application.persistentDataPath + @"\ObjectPosition.json";
         lastPosition = thisTransform.position;
         lastRotation = thisTransform.rotation;

         //Generate writter object
         StreamWriter writer = new StreamWriter(outputPath);
         writer.WriteLine(JsonUtility.ToJson(this));
         writer.Close();
         Debug.Log("Outputting to: " + outputPath);
    }

    void LoadObject() {

        //Create input path
        string inputPath = Application.persistentDataPath + @"\ObjectPosition.json";
    
        StreamReader reader = new StreamReader(inputPath);
        string JSONString = reader.ReadToEnd();
        Debug.Log("Reading: " + JSONString);
        JsonUtility.FromJsonOverwrite(JSONString, this);
        reader.Close();

        thisTransform.position = lastPosition;
        thisTransform.rotation = lastRotation;
    }

    void OnDestroy() {

        SaveObject();
    }

    void Start() {

        LoadObject();
    }

    void Awake() {

        thisTransform = GetComponent<Transform>();
    }
}
