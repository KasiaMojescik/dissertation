using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {


    public Transform arrow;
    private Transform playerTransform;
    public PlayerMove objective;


    

	// Use this for initialization
	void Start () {

        playerTransform = FindObjectOfType<PlayerMove>().transform;

        GameObject[] candidates = GameObject.FindGameObjectsWithTag("Pick Up");
        if (candidates.Length != 0)
        {
            //  Vector3 dir = playerTransform.InverseTransformPoint(objective.FindTarget().position);
           //   float a = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
           //   a += 180;
           //   arrow.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
