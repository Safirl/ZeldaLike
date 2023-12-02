﻿/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes) and MMI Teaching (IUT Bordeaux Montaigne)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {
    public List<DialogPage> m_dialogWithPlayer;

    public List<DialogPage> GetDialog()
    {
        return m_dialogWithPlayer;
    }

    public void Clear()
    {
        m_dialogWithPlayer.Clear();
    }

    public void SetOneLineDialog(string message)
    {
        DialogPage newPageToAdd;
        newPageToAdd.color = Color.black;
        newPageToAdd.text = message;

        m_dialogWithPlayer.Add(newPageToAdd);
    }
}
