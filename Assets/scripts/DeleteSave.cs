using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{
    
    string savename;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveDelete()
    {
        Save mySave = new Save();
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(savename, data);
        PlayerPrefs.Save();
    }
    public void DeleteSave1()
    {
        savename = "Save1";
    }
    public void DeleteSave2()
    {
        savename = "Save2";
    }
    public void DeleteSave3()
    {
        savename = "Save3";
    }
}
