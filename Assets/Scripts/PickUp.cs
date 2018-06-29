using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private void Start()
    {
        objective = FindObjectOfType<Objective>();
    }

    private PlayerMove playerMove;
    // new code
    private Objective objective;
    private bool pickUpActive = false;

    

    public void ActivatePickUp()
    {
        pickUpActive = true;
    }
}
