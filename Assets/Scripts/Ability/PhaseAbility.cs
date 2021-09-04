using UnityEngine;
using System.Collections;

public class PhaseAbility : MonoBehaviour, IAbility
{
    public void Activate()
    {
        PhaseOn();
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3f);
        PhaseOff();
    }

    private void PhaseOn()
    {
        print("Phase on!");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), true);
    }

    private void PhaseOff()
    {
        print("Phase off");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), false);
    }
}
