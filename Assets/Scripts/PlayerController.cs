using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Camera camera;
    public NavMeshAgent agent;
    public GameObject arrowX;


    // new code
   
    public Objective objective;


    private Rigidbody rb;
    private int count;

   // private Vector3 targetPosition;
   // private NavMeshAgent directionNavAgent;

    void Start()
    {


        rb = GetComponent<Rigidbody>();
        count = 0;
        //SetCountText();
        //finishText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
        //    arrow.SetActive(false);
        }
    }





    /*void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }*/

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }*/
}