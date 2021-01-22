using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class meshEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent activateCubeTrigger;

    [SerializeField] private UnityEvent deactivateCubeTrigger;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            activateCubeTrigger.Invoke();
            Debug.Log("pad");
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            deactivateCubeTrigger.Invoke();
            Debug.Log("paddeactivate");
        }
        
    }    
}
