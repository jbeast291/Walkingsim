using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenue : MonoBehaviour
{
    Dropdown Var_Dropdown;
    int Var_DropdownValue;
    int Counter = 0;

    void Start()
    {
        Var_Dropdown = GetComponent<Dropdown>();
        Debug.Log("Starting Dropdown Value : " + Var_Dropdown.value);

        Var_Dropdown.onValueChanged.AddListener(delegate {
                DropdownValueChanged();
            });
    }

    void Update()
    {
        Var_DropdownValue = Var_Dropdown.value;

        if (Var_DropdownValue == 0 && Counter == 1)//2k
        {
        Debug.Log("New Dropdown Value : " + Var_Dropdown.value);
        Counter = 2;
        Screen.SetResolution(2560, 1440, true);
        }

        if (Var_DropdownValue == 1 && Counter == 1)//1080
        {
        Debug.Log("New Dropdown Value : " + Var_Dropdown.value);
        Counter = 2;
        Screen.SetResolution(1920, 1080, true);
        }

        if (Var_DropdownValue == 2 && Counter == 1)//720
        {
        Debug.Log("New Dropdown Value : " + Var_Dropdown.value);
        Counter = 2;
        Screen.SetResolution(1280, 720, true);
        }
    }

        void DropdownValueChanged()
    {
        Counter = 1;
    }
}
