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

    public bool PlaySound = true;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            activateCubeTrigger.Invoke();
            if (PlaySound)
            {
                Visablepadon.Play();
            }
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            deactivateCubeTrigger.Invoke();
            if (PlaySound)
            {
            Visablepadoff.Play();
            }
        }
        
    }
}
