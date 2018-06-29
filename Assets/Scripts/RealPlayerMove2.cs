using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RealPlayerMove2 : MonoBehaviour
{

    [SerializeField]
    Transform destination;
    NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    public Transform arrowHolder;
    private int currentArrowIndex = 0;
    private int numberOfArrows;
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

        if (arrowHolder != null)
        {
            numberOfArrows = arrowHolder.childCount;
            Transform currentChild = arrowHolder.GetChild(currentArrowIndex);
            currentChild.gameObject.SetActive(true);
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

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Collision happaning with the real player.");

        if (other.CompareTag("Arrow"))
        {

            Debug.Log("Collision tag is Arrow and i am doing some stuff");

            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);

            if (currentArrowIndex < numberOfArrows - 1)
            {
                arrowHolder.GetChild(currentArrowIndex + 1).gameObject.SetActive(true);
                currentArrowIndex++;
            }

            //FindObjectOfType<AudioManager>().Play("left");
        }

    }
}
