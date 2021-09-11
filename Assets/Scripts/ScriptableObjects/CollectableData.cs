/*****************************************************************************
// File Name :         CollectableData.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A SO that holds a collectable's data (UI icon, etc.).
*****************************************************************************/
using UnityEngine;

[CreateAssetMenu(menuName = "Collectables/Collectable Data", fileName = "New Collectable Data")]
public class CollectableData : ScriptableObject
{
    [Tooltip("The collectable's UI icon prefab.")]
    [SerializeField] private GameObject icon;
    /// <summary>
    /// The collectable's UI icon prefab.
    /// </summary>
    public GameObject Icon { get { return icon; } }
}