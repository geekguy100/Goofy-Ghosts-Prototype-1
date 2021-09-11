/*****************************************************************************
// File Name :         GuardSiphonBehavior.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Defines behaviour for when Guards are siphoned by the player.
*****************************************************************************/
using UnityEngine;

public class GuardSiphonBehavior : MonoBehaviour, ISiphonable
{
    [Tooltip("The HealthManager of the entity to siphon from.")]
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private float healthToSiphon;

    public void OnSiphoned()
    {
        healthManager.CurrentHealth += healthToSiphon;
        //TODO: Remove health from guard as well, but that's not a part of our game.
    }
}