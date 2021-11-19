using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenue : MonoBehaviour
{

    public void Level1 ()
    {
        SceneManager.LoadScene(1);
        //PauseMenue.GameIsPaused = false;
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = -320.1251f;
        mySave.y = 120f;
        mySave.z = -200f;
        mySave.level = "Level1";
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(systemLoadedData.Savename, data);
        PlayerPrefs.Save();
    }
    public void Leve2 ()
    {
        SceneManager.LoadScene(2);
        //PauseMenue.GameIsPaused = false;
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = -544f;
        mySave.y = 268f;
        mySave.z = 295f;
        mySave.level = "Level2";
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(systemLoadedData.Savename, data);
        PlayerPrefs.Save();
    }
    public void Level3 ()
    {
        SceneManager.LoadScene(3);
        PauseMenue.GameIsPaused = false;
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = -339f;
        mySave.y = 328f;
        mySave.z = -370f;
        mySave.level = "Level3";
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(systemLoadedData.Savename, data);
        PlayerPrefs.Save();
    }
    public void Level4 ()
    {
        SceneManager.LoadScene(4);
        PauseMenue.GameIsPaused = false;
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = 3402f;
        mySave.y = 580f;
        mySave.z = 368f;
        mySave.level = "Level4";
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(systemLoadedData.Savename, data);
        PlayerPrefs.Save();
    }
    public void Level5 ()
    {
        SceneManager.LoadScene(5);
        PauseMenue.GameIsPaused = false;
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = 2733f;
        mySave.y = 546f;
        mySave.z = 363f;
        mySave.level = "Level5";
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(systemLoadedData.Savename, data);
        PlayerPrefs.Save();
    }
    public void Level6 ()
    {
        SceneManager.LoadScene(6);
        PauseMenue.GameIsPaused = false;
        string systemdata = PlayerPrefs.GetString("MySettings");
        Save systemLoadedData = JsonUtility.FromJson<Save>(systemdata);

        Save mySave = new Save();
        mySave.x = 2745;
        mySave.y = 540;
        mySave.z = 264;
        mySave.level = "Level6";
        mySave.objectstosave = GameObject.FindGameObjectsWithTag("savethisobject");
        string data = JsonUtility.ToJson(mySave);
        PlayerPrefs.SetString(systemLoadedData.Savename, data);
        PlayerPrefs.Save();
    }

}
