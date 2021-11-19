using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{

    public bool devmode = true;

    public GameObject levelmenuebutton; 

    void Start()
    {
        if(devmode == true)
        {
            Debug.Log("devmode active");
        }
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
        //PauseMenue.GameIsPaused = false;
        
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void Update()
    {   
        if(devmode == true)
        {
            levelmenuebutton.SetActive(true);
        }
        if(devmode == false)
        {
            levelmenuebutton.SetActive(false);
        }
    }
}
