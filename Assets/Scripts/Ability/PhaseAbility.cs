using UnityEngine;
using System.Collections;

public class PhaseAbility : MonoBehaviour, IAbility
{
    private bool coolingDown = false;

    public void Activate()
    {
        PhaseOn();
        StartCoroutine(Cooldown());
    }

    #region -- Ability Functionality --
    private void PhaseOn()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), true);
    }

    private void PhaseOff()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), false);
    }
    #endregion

    #region -- Cooldown Functionality --
    private IEnumerator Cooldown()
    {
        coolingDown = true;
        yield return new WaitForSeconds(GetCooldownTime());
        coolingDown = false;
        PhaseOff();
    }

    public float GetCooldownTime()
    {
        return 3f;
    }

    public bool IsCoolingDown()
    {
        return coolingDown;
    }
    #endregion
}