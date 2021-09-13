/*****************************************************************************
// File Name :         DontDestroyOnLoad.cs
// Author :            Kyle Grenier
// Creation Date :     09/12/2021
//
// Brief Description : Prevents the GameObject from being destroyed on scene load.
*****************************************************************************/
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
