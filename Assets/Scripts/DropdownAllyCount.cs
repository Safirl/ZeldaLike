using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownAllyCount : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public Dropdown dropdown;

    void Start(){}

    public void UpdateDropdownOptions()
    {
        dropdown.ClearOptions();
        

        for (int i = 1; i <= gameManager.GetNumberAlliesAlive(); i++)
        {
            dropdown.options.Add(new Dropdown.OptionData(""+i));
        }

        dropdown.RefreshShownValue();
    }
}
