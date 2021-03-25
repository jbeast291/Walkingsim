using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meshActivate : MonoBehaviour
{
    [SerializeField] private GameObject myCube;
    
    Renderer rend;
    public Rigidbody RigidBody;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
    }



    public void ActivateCube()
    {
        Color VisableColor = new Color(0,1,0.06f,0.5f);
        rend.material.SetColor("_Color", VisableColor);
    }



    public void DeactivateCube()
    {
        Color VisableColor = new Color(0.5f,0.5f,0.5f,0.007843137254902f);
        rend.material.SetColor("_Color", VisableColor);
    }

    public void ActivateRigidBody()
    {
        RigidBody.isKinematic = false;
    }

    public void DeactivateRigidBody()
    {
        RigidBody.isKinematic = true;
    }
}
 