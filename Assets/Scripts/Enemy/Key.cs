/*****************************************************************************
// File Name :         Key.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Defines the behaviour for the Key object.
*****************************************************************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Key : ICollectable
{
    private Collider2D col;

    [Tooltip("The amplitude of the key bobbing.")]
    [SerializeField] private float bobAmplitude;
    [Tooltip("The frequency of the key bobbing.")]
    [SerializeField] private float bobFrequency;

    [SerializeField] private bool startDropped = false;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    private void Start()
    {
        if (startDropped)
            OnDropped();
    }

    /// <summary>
    /// Enables the 
    /// </summary>
    public void OnDropped()
    {
        col.enabled = true;
        StartCoroutine(BobKey());
    }

    /// <summary>
    /// Bobs the key up and down.
    /// </summary>
    private IEnumerator BobKey()
    {
        Vector2 initialPos = transform.localPosition;
        float counter = 0f;

        while (true)
        {
            // The position the key will bob to.
            Vector3 bobPos = transform.localPosition;

            counter += Time.deltaTime;
            bobPos.y = (Mathf.Sin(counter * bobFrequency) * bobAmplitude) + initialPos.y;
            transform.localPosition = bobPos;

            counter %= 360f;

            yield return null;
        }
    }

    /// <summary>
    /// Method invoked when the player enters the collectable's trigger.
    /// </summary>
    protected override void PerformAction()
    {
        collectableChannel.RaiseEvent(data);
        Destroy(gameObject);
    }
}