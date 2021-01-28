using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenue : MonoBehaviour
{

    public void Level1 ()
    {
        SceneManager.LoadScene(1);
        PauseMenue.GameIsPaused = false;
        
    }
    public void Leve2 ()
    {
        SceneManager.LoadScene(2);
        PauseMenue.GameIsPaused = false;
        
    }
    public void Level3 ()
    {
        SceneManager.LoadScene(3);
        PauseMenue.GameIsPaused = false;
        
    }
    public void Level4 ()
    {
        SceneManager.LoadScene(4);
        PauseMenue.GameIsPaused = false;
        
    }
    public void Level5 ()
    {
        SceneManager.LoadScene(5);
        PauseMenue.GameIsPaused = false;
        
    }

}
