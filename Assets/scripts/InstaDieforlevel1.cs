using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstaDieforlevel1 : MonoBehaviour
{
    public int level;

    public Collider collide;

    Scene currentLevel;
     //private void Start() {
     //    currentLevel = SceneManager.GetActiveScene();

     //}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            SceneManager.LoadScene(level);

        }
    }

}
