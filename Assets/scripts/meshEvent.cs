using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class meshEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent activateCubeTrigger;

    [SerializeField] private UnityEvent deactivateCubeTrigger;

    public AudioSource Visablepadon;
    public AudioSource Visablepadoff;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            activateCubeTrigger.Invoke();
            Visablepadon.Play();
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            deactivateCubeTrigger.Invoke();
        }
        
    }    
}
