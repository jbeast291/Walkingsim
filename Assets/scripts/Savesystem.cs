using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Savesystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string data = PlayerPrefs.GetString("MySettings");
        Save loadedData = JsonUtility.FromJson<Save>(data);
        Debug.Log(loadedData.lastLevelLoaded);
    }
    public void Save1()
    {
        Save mySave = new Save();
        mySave.Savename = "Save1";
        SceneManager.LoadScene("Level1");
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString("MySettings", data);
        PlayerPrefs.Save();
    }
    public void Save2()
    {
        Save mySave = new Save();
        mySave.Savename = "Save2";
        SceneManager.LoadScene("Level1");
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString("MySettings", data);
        PlayerPrefs.Save();
    }
    public void Save3()
    {
        Save mySave = new Save();
        mySave.Savename = "Save3";
        SceneManager.LoadScene("Level1");
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString("MySettings", data);
        PlayerPrefs.Save();
    }
    //  public void load1()
    //  {
    //      string data = PlayerPrefs.GetString("Save1");
    //      Save loadedData = JsonUtility.FromJson<Save>(data);
    //  }
    //  public void load2()
    //  {
    //      string data = PlayerPrefs.GetString("Save2");
    //      Save loadedData = JsonUtility.FromJson<Save>(data);
    //  }
    //  public void load3()
    //  {
    //      string data = PlayerPrefs.GetString("Save3");
    //     Save loadedData = JsonUtility.FromJson<Save>(data);
    //  }
}

