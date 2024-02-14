using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class OrbitTest : MonoBehaviour
{
    public GameObject PrimaryTarget;    // hard coded via inspector for testing
    public GameObject ChaseTarget;      // hard coded via inspector for testing
    public float Velocity = 5f;
    public float RevolutionSpeed = 20f;
    public float Radius = 15f;
 
    private Vector3 Direction;
 
    private void Start()
    {
        if(PrimaryTarget==null)
            Debug.LogException(new System.Exception(this.name + ": Primary Target Not Set"));
   
        ChaseTarget.transform.SetParent(PrimaryTarget.transform);           // Set the target we will chase (orbit) to be parented to the Primary Target
        ChaseTarget.transform.rotation = PrimaryTarget.transform.rotation;  // Ensure rotation matches to prevent errors
    }
 
    private void Update()
    {
        Vector3 Direction = (gameObject.transform.position - ChaseTarget.transform.position).normalized;    // Get direction from us to the chase target
 
        // As long as we are within Radius - Excecute orbital mode
        if (Vector3.Distance(transform.position, ChaseTarget.transform.position) <= Radius)
        {
            ChaseTarget.transform.position = (ChaseTarget.transform.position - PrimaryTarget.transform.position).normalized * Radius + PrimaryTarget.transform.position;    // Some maths (probably don't need this anymore)
            ChaseTarget.transform.RotateAround(PrimaryTarget.transform.position, Vector3.up, RevolutionSpeed * Time.deltaTime);     // Rotate around the Primary target, chase target is primarilly for direction facing purposes now
        }
        // If we are not within Radius - Exceute follow mode
        else if (Vector3.Distance(transform.position, ChaseTarget.transform.position) > Radius)
        {
            ChaseTarget.transform.position = PrimaryTarget.transform.position - -Direction * Radius;    // Move the chasetarget back from our primary target by N units based on direction
        }
 
        transform.LookAt(ChaseTarget.transform.position);   // change this to a Q Slerp later - it target moves sharply it doesn't look right
        transform.position = Vector3.MoveTowards(transform.position, ChaseTarget.transform.position, Velocity * Time.deltaTime);    // can change to a more calculated approach later.
    }
}