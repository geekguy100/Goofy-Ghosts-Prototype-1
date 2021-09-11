/*****************************************************************************
// File Name :         ISiphonable.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : An interface all game objects that the can have their health siphoned / leeched must implement.
*****************************************************************************/
using UnityEngine;

public interface ISiphonable
{
    void OnSiphoned();
}