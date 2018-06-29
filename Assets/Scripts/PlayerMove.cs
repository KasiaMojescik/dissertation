using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    Transform destination;
    NavMeshAgent navMeshAgent;
  public Transform arrow;
    //private Transform playerTransform;
    public Transform pointerTarget;


    Vector3[] positions;
    int currentPossitionIndex = 0;

    void Start()
    {
        //playerTransform = this.transform;
        Debug.Log("Starting...");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("This NavMeshAgent is not attached to " + gameObject.name);
        }
        else
        {
            positions = new Vector3[256];
            InvokeRepeating("DrawArrow",0,1);
            SetDestination();
        }

    }

   


    
    private void DrawArrow()
    {
        positions[currentPossitionIndex] = transform.position;
        Debug.Log(transform.position);
        Debug.Log(positions);
        
        Vector3 startingPoint = new Vector3();
        startingPoint.x = positions[currentPossitionIndex].x;
        startingPoint.y = positions[currentPossitionIndex].y;
        startingPoint.z = positions[currentPossitionIndex].z;
        Debug.Log("Rotation: " + Quaternion.LookRotation(positions[currentPossitionIndex], startingPoint));
        Debug.Log("position of creation: " + startingPoint.ToString());
        Debug.Log("Looking at position: " + positions[currentPossitionIndex].ToString());
        if (currentPossitionIndex > 0)
        {
            Transform currentArrow = Instantiate(arrow, positions[currentPossitionIndex - 1], Quaternion.LookRotation(positions[currentPossitionIndex], startingPoint));
            currentArrow.LookAt(positions[currentPossitionIndex]);
            //currentArrow.LookAt(new Vector3(pointerTarget.position.x, pointerTarget.position.y, pointerTarget.position.z));
            Debug.Log("Before rotation changes: " + currentArrow.rotation.ToString());
            //currentArrow.rotation.Set(currentArrow.rotation.x,currentArrow.rotation.y - 90.0f, currentArrow.rotation.z, currentArrow.rotation.w);
            currentArrow.Rotate(0,-90,0);
            Debug.Log("After rotation changes: " + currentArrow.rotation.ToString());
            
        }
        currentPossitionIndex++;
    } 


    public Transform FindTarget()
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag("Pick Up");
        
        Debug.Log(candidates.ToString());
        Debug.Log(candidates.Length);
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (candidates.Length == 0)
            return null;

        closest = candidates[0].transform;
        for (int i = 1; i < candidates.Length; ++i)
        {
            float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                closest = candidates[i].transform;
                minDistance = distance;
            }
        }
        Debug.Log("The closest one is: " + closest.tag);
        return closest;
    }

    public void SetDestination()
    {

        destination = FindTarget();
        Debug.Log("We are in setDestination");
        if (destination != null)
        {
           // for (int i=0; i<4; i++) {
            //    Debug.Log("we are on the loop agian.");
               
                Vector3 targetVector = destination.transform.position;
                navMeshAgent.SetDestination(targetVector);

            //  Vector3 dir = playerTransform.InverseTransformPoint(targetVector);
            //  float a = Mathf.Atan2(targetVector.x, targetVector.z) * Mathf.Rad2Deg;
            //  a += 180;
            //   arrow.transform.localEulerAngles = new Vector3(0, 180, 0);
            //}
            // SetDestination();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collision happaning here...");
     //   Debug.Log("Collision.gameObject tag: " + collision.gameObject.tag);
      //  Debug.Log("Collision.collider tag: " + collision.collider.tag);
        if (other.CompareTag("Pick Up"))
        {
            /* if (pickUpActive)
             {
                 objective.NextPickUp();
             }*/
            Debug.Log("Collision tag is the same and i am doing some stuff");
            other.gameObject.tag = "Untagged"; // Remove the tag so that FindTarget won't return it
                                         
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("ding_sound");
            // Destroy(collision.collider.gameObject);
            // Debug.Log("Did some stuff, calling set destination");
            SetDestination();
        }
        
    }
}
