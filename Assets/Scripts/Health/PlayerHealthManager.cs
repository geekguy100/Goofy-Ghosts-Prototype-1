/*****************************************************************************
// File Name :         PlayerHealthManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/12/2021
//
// Brief Description : Resets the player's health on death.
*****************************************************************************/

public class PlayerHealthManager : HealthManager
{
    private void Awake()
    {
        healthData.HealthEmptyChannel.OnEventRaised += Init;
    }
}
