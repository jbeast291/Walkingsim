using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meshActivate : MonoBehaviour
{
    [SerializeField] private GameObject myCube;

    public Material invisable;
    public Material solidcolor;
    
    //[SerializeField] private GameObject Cube;


    public void ActivateCube()
    {
        Debug.Log("visable");
        myCube.GetComponent<MeshRenderer>().materials[0] = solidcolor;
    }


    public void DeactivateCube()
    {
        Debug.Log("invisable");
    }
}
 