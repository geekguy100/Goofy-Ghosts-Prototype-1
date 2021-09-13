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

    [SerializeField] private GameObject fovPrefab;
    private FieldOfView fov;
    [SerializeField] private Transform flashlightPos;

    private bool stunned = false;

    /// <summary>
    /// Assigns the guard's initial position
    /// </summary>
    void Start()
    {
        CreateFOV();

        // Guard will automatically start at it first waypoint
        transform.position = waypoint[waypointCount].transform.position;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (isIdle)
        {
            //Changes direction in idle state
            InvokeRepeating("IdlePhase", 0, turnTime);
        }

        if (sr.flipX)
        {
            FlipX(true);
            sr.flipX = false;
        }

    }

    private void CreateFOV()
    {
        fov = Instantiate(fovPrefab, Vector3.zero, Quaternion.identity).GetComponent<FieldOfView>();
    }

    /// <summary>
    /// Primarily used to swap between states.
    /// </summary>
    void FixedUpdate()
    {
        if (isIdle == false && !stunned)
        {
            anim.SetBool("isPatrol", true);
            PatrolPhase();
        }
    }

    public void OnStunned()
    {
        stunned = true;
        anim.SetBool("stunned", true);
        anim.SetBool("isPatrol", false);
        fov.gameObject.SetActive(false);
    }

    public void OnUnstunned()
    {
        stunned = false;
        anim.SetBool("stunned", false);
        anim.SetBool("isPatrol", true);
        fov.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!stunned)
        {
            fov.SetAimDirection(Vector3.up * transform.localScale.x);
            fov.SetOrigin(flashlightPos.position);
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
            FlipX(false);
        // If not, face left
        else
            FlipX(true);
    }

    private bool isFacingRight = true;

    void IdlePhase()
    {
        if (isFacingRight == true)
        {
            FlipX(true);
            isFacingRight = false;
        }
        else
        {
            FlipX(false);
            isFacingRight = true;
        } 
    }

    private void FlipX(bool flipX)
    {
        Vector3 scale = transform.localScale;
        scale.x = flipX ? -1 : 1;

        transform.localScale = scale;
    }
}
