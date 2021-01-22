using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meshActivate : MonoBehaviour
{
    [SerializeField] private GameObject myCube;
    
    Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    //meshRenderer.materials[1] = invisable;
    
    // public void ActivateCube()
    // {
    //     bool isVisable = false;

    //     if(!isVisable)
    //     {
    //         Color VisableColor = new Color(0,1,0.06f,0.5f);
    //         rend.material.SetColor("_Color", VisableColor);
    //         Debug.Log("visable");
    //         isVisable = true;
    //     }

    //     else if(isVisable)
    //     {
    //         Color VisableColor = new Color(0,1,0.06f,0.1f);
    //         rend.material.SetColor("_Color", VisableColor);
    //         isVisable = false;
    //         Debug.Log("invisable");
    //     }

    //     else
    //     {
    //        Debug.Log("something went wrong in the mesh activate script!"); 
    //     }

    // }
    public void ActivateCube()
    {
        Color VisableColor = new Color(0,1,0.06f,0.5f);
        rend.material.SetColor("_Color", VisableColor);
        Debug.Log("visable");
    }
    public void DeactivateCube()
    {
        Color VisableColor = new Color(0.5f,0.5f,0.5f,0.007843137254902f);
        rend.material.SetColor("_Color", VisableColor);
        Debug.Log("invisable");
    }
}
 