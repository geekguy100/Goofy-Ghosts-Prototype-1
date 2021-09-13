/*****************************************************************************
// File Name :         PlayerHealthManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/12/2021
//
// Brief Description : Resets the player's health on death.
*****************************************************************************/

public class PlayerHealthManager : HealthManager
{
    private void OnEnable()
    {
        healthData.HealthEmptyChannel.OnEventRaised += Init;
    }

    private void OnDisable()
    {
        healthData.HealthEmptyChannel.OnEventRaised -= Init;
    }
}
