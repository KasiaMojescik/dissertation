using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RealPlayerMove : MonoBehaviour
{

    [SerializeField]
    Transform destination;
    NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    public Transform arrow;
    //private Transform playerTransform;

    //CharacterController charControl;
    public float walkSpeed;


    Vector3[] possitions;
    int currentPossitionIndex = 0;
    /*
    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //playerTransform = this.transform;
        Debug.Log("Starting...");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("This NavMeshAgent is not attached to " + gameObject.name);
        }
        else
        {
            possitions = new Vector3[256];
           // InvokeRepeating("DrawArrow", 0, 2);
             //SetDestination();
           
        }

    }






    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(moveHorizontal * walkSpeed * Time.deltaTime, 0f, moveVertical * walkSpeed * Time.deltaTime);
    }
}
