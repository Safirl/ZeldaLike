using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputMessage : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private PlayerBehavior playerBehavior;

    public void OnSelect(BaseEventData eventData)
    {
        playerBehavior.SetIsWriting(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        playerBehavior.SetIsWriting(false);
    }
}

