using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    public void SaveGame()
    {
        Save mySave = new Save();
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString("MySettings", data);
        PlayerPrefs.Save();
    }
    public void LoadGame()
    {
        string data = PlayerPrefs.GetString("MySettings");
        Save loadedData = JsonUtility.FromJson<Save>(data);

        GameObject.Find("Player2.0").transform.position += new Vector3(loadedData.x, loadedData.y, loadedData.z);

        GameObject[] objectstoload = GameObject.FindGameObjectsWithTag("savethisobject");
            
        for (int i = 0; i < objectstoload.Length; i++)
        {
            Vector3 v = new Vector3(loadedData.Coords[i], loadedData.Coords[i+1], loadedData.Coords[1+2]);
            objectstoload[i].transform.position += v;
        }

    }
    void start()
    {
        LoadGame();
    }
}
public class Save
{
    public float x = GameObject.Find("Player2.0").transform.localPosition.x;
    public float y = GameObject.Find("Player2.0").transform.localPosition.y;
    public float z = GameObject.Find("Player2.0").transform.localPosition.z;

    public static GameObject[] objectstosave = GameObject.FindGameObjectsWithTag("savethisobject");
    public float[] Coords = new float[objectstosave.Length * 3];
    public Save()
    {
    for (int i = 0; i < objectstosave.Length; i++)
    {
        Coords[i] = objectstosave[i].transform.localPosition.x;
        Coords[i+1] = objectstosave[i].transform.localPosition.y;
        Coords[i+2] = objectstosave[i].transform.localPosition.z;
    }
    }
    
}
