using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNavigation : MonoBehaviour {

    [SerializeField]
    public Transform destination;
    //public Transform arrow;
	
	// Update is called once per frame
	void Update () {
        destination = FindTarget();
        if (destination != null)
        {
           Vector3 targetPosition = destination.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
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
    
    /*
    void DirectArrow()
    {
        destination = FindTarget();
        if (destination != null)
        {
            Vector3 targetPosition = destination.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            /*
            Debug.Log("we are on the loop agian.");
            
            Vector3 targetVector = destination.transform.position;
            float a = Mathf.Atan2(targetVector.x, targetVector.z) * Mathf.Rad2Deg;
            a += 180;
            destination.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    } */
    }
