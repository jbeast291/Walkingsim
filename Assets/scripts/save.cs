using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void SaveGame()
    {
        Save mySave = new Save();
        string data = JsonUtility.ToJson(SaveData);
        PlayerPrefs.SetString("MySettings", data);
        PlayerPrefs.Save();
    }
    public void LoadGame()
    {
        string data = PlayerPrefs.GetString("MySettings");
        Save loadedData = JsonUtility.FromJson<Save>(data);

        GameObject.Find("Player2.0").Vector3.x = loadedData.x;
        GameObject.Find("Player2.0").Vector3.x = loadedData.y;
        GameObject.Find("Player2.0").Vector3.x = loadedData.z;

        GameObject[] objectstoload = GameObject.FindGameObjectsWithTag("savethisobject");
            
        for (int i = 0; i < objectstoload.Length; i++)
        {
            objectstoload[i].Vector3.x = loadedData.Coords[i];
            objectstoload[i].Vector3.y = loadedData.Coords[i+1];
            objectstoload[i].Vector3.z = loadedData.Coords[i+2];
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
public class Save
{

    float x = GameObject.Find("Player2.0").Vector3.x;
    float y = GameObject.Find("Player2.0").Vector3.y;
    float z = GameObject.Find("Player2.0").Vector3.z;

    GameObject[] objectstosave = GameObject.FindGameObjectsWithTag("savethisobject");

    public float[] Coords = new Float[objectstosave.Length * 3];
    public Save()
    {
    for (int i = 0; i < objectstosave.Length; i++)
    {
        Coords[i] = objectstosave[i].Vector3.x;
        Coords[i+1] = objectstosave[i].Vector3.y;
        Coords[i+2] = objectstosave[i].Vector3.z;
    }
    }
    
}
