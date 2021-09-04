using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class PhaseAbility : MonoBehaviour, IAbility
{
    private SpriteRenderer rend;
    private bool coolingDown = false;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void Activate()
    {
        PhaseOn();
        StartCoroutine(Cooldown());
    }

    #region -- Ability Functionality --
    private void PhaseOn()
    {
        Color c = rend.color;
        c.a /= 2;
        rend.color = c;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), true);
    }

    private void PhaseOff()
    {
        Color c = rend.color;
        c.a *= 2;
        rend.color = c;

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