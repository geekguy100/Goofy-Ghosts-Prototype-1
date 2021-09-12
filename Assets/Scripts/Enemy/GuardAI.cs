/*****************************************************************************
// File Name :         GuardAI.cs
// Author :            Kyle Grenier / Tristan Blair
// Creation Date :     #CREATIONDATE#
//
// Brief Description : Handles the movement AI for the guards
*****************************************************************************/
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    [Tooltip("Waypoint objects guard wil travel to (in order)")]
    [SerializeField]
    Transform[] waypoint;

    [Tooltip("Speed guard moves at")]
    [SerializeField]
    float guardSpeed = 4f;

    [Tooltip("Whether guard moves or not")]
    [SerializeField]
    bool isIdle;

    [Tooltip("How long an idle guard waits to turn")]
    [SerializeField]
    float turnTime = 2f;

    int waypointCount = 0;

    SpriteRenderer sr;
    Animator anim;

    /// <summary>
    /// Assigns the guard's initial position
    /// </summary>
    void Start()
    {
        // Guard will automatically start at it first waypoint
        transform.position = waypoint[waypointCount].transform.position;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (isIdle)
        {
            //Changes direction in idle state
            InvokeRepeating("IdlePhase", 0, turnTime);
        }

    }

    /// <summary>
    /// Primarily used to swap between states.
    /// </summary>
    void FixedUpdate()
    {
        if (isIdle == false)
        {
            anim.SetBool("isPatrol", true);
            PatrolPhase();
        }
    }

    /// <summary>
    /// Called when the ability is activated.
    /// </summary>
    void PatrolPhase()
    {
        // Guard will move its position toward its next waypoint
        transform.position = Vector2.MoveTowards(transform.position,
            waypoint[waypointCount].transform.position,
            guardSpeed * Time.deltaTime);

        // If guard reaches its next waypoint, advance to the next one
        if(transform.position == waypoint[waypointCount].transform.position)
            waypointCount += 1;

        // If guard reaches all of its waypoints, start over again
        if(waypointCount == waypoint.Length)
            waypointCount = 0;

        // If the next waypoint is to the right of the guard,
        // keep facing right
        if(waypoint[waypointCount].transform.position.x >=
            transform.position.x)
            sr.flipX = false;
        // If not, face left
        else
            sr.flipX = true;
    }

    private bool isFacingRight = true;

    void IdlePhase()
    {
        if (isFacingRight == true)
        {
            sr.flipX = true;
            isFacingRight = false;
        }
        else
        {
            sr.flipX = false;
            isFacingRight = true;
        } 
    }
}
