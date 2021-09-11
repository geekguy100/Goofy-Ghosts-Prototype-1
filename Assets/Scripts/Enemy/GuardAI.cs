/*****************************************************************************
// File Name :         GuardAI.cs
// Author :            Kyle Grenier / Tristan Blair
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
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

    int waypointCount = 0;

    SpriteRenderer sr;

    /// <summary>
    /// Assigns the guard's initial position
    /// </summary>
    void Start()
    {
        // Guard will automatically start at it first waypoint
        transform.position = waypoint[waypointCount].transform.position;

        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Primarily used to swap between states.
    /// </summary>
    void FixedUpdate()
    {
        // Default state
        PatrolPhase();
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

        int nextWaypoint = waypointCount + 1;

        // Prevents the code from trying to find an index outside
        // of the array's bounds
        if(nextWaypoint >= waypoint.Length)
            nextWaypoint = 0;

        // If the next waypoint is to the left of the current waypoint,
        // flip the guard's sprite
        if(waypoint[waypointCount].transform.position.x <=
            waypoint[nextWaypoint].transform.position.x)
            sr.flipX = false;
        else
            sr.flipX = true;
    }
}
