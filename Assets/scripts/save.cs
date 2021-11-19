using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class save : MonoBehaviour
{
    public Rigidbodyscript a;
    public void SaveGame()
    {
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save loadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = GameObject.Find("Capsule").transform.position.x;
        mySave.y = GameObject.Find("Capsule").transform.position.y;
        mySave.z = GameObject.Find("Capsule").transform.position.z;
        mySave.objectstosave = GameObject.FindGameObjectsWithTag("savethisobject");
        mySave.rotation = new Vector3[mySave.objectstosave.Length];
        mySave.Coords = new float[mySave.objectstosave.Length * 3];
        mySave.isthick = a.isTHICK;
        for (int i = 0, j = 0; j < mySave.objectstosave.Length; j++, i+=3)
        {
            mySave.rotation[j] = mySave.objectstosave[j].transform.eulerAngles;
            mySave.Coords[i] = mySave.objectstosave[j].transform.position.x;
            mySave.Coords[i+1] = mySave.objectstosave[j].transform.position.y;
            mySave.Coords[i+2] = mySave.objectstosave[j].transform.position.z;
        }
        Scene MyScene = SceneManager.GetActiveScene();
        mySave.level = MyScene.name;
        Debug.Log(MyScene.name);
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(loadedData.Savename, data);
        PlayerPrefs.Save();
    }
    public void LoadGame()
    {
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        string data = PlayerPrefs.GetString(systemLoadedData.Savename);
        Save loadedData = JsonUtility.FromJson<Save>(data);
        GameObject.Find("Capsule").transform.position = transform.position - transform.position + new Vector3(loadedData.x, loadedData.y, loadedData.z);
        GameObject[] objectstoload = GameObject.FindGameObjectsWithTag("savethisobject");
        Debug.Log(objectstoload.Length);
        try
        {
            for (int i = 0, j = 0; j < objectstoload.Length; j++, i+=3)
            {
                Vector3 v = new Vector3(loadedData.Coords[i], loadedData.Coords[i+1], loadedData.Coords[i+2]);
                objectstoload[j].transform.eulerAngles = loadedData.rotation[j];
                objectstoload[j].transform.position = v;   
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }

        if(loadedData.isthick == true)
        {
            a.setthick();
        }
        if(loadedData.isthick == false)
        {
            a.setunthick();
        }
        Scene myScene = SceneManager.GetActiveScene();
        Debug.Log(loadedData.level);
        if(loadedData.level == myScene.name)
        {
            return;
        }
        if(loadedData.level == string.Empty)
        {
            return;
        }
        SceneManager.LoadScene(loadedData.level);

    }

    void Start()
    {
        LoadGame();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SystemSave();
        }
    }
    public void SystemSave()
    {
        Save mySave = new Save();
        Scene LoadedScene = SceneManager.GetActiveScene();
        mySave.lastLevelLoaded = LoadedScene.name;


        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString("MySettings", data);
        PlayerPrefs.Save(); 
    }
}

[Serializable]
public class Save
{
    public float x;
    public float y;
    public float z;
    public bool isthick;

    public GameObject[] objectstosave;

    public Vector3[] rotation;
    public float[] Coords;

    public string level;

    public string Save1;

    public string lastLevelLoaded;
    public string Savename;
}
