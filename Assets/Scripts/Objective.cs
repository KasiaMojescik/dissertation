using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

    private List<Transform> pickups = new List<Transform>();

   // public Material activePickUp;
   // public Material inactivePickUp;
   // public Material finalPickUp;

    public Text finishText;
    public Text countElementsText;
    private int count;

    private int pickupsCollected = 0;

    // Use this for initialization
    void Start() {

       // FindObjectOfType<GameScene>().objective = this;

        count = 0;
        // at the beginning of the trial, assign inactive to all Pick Up objects
        foreach (Transform t in transform)
        {
            pickups.Add(t);
          //  t.GetComponent<MeshRenderer>().material = inactivePickUp;
        }
        if (pickups.Count == 0)
        {
            Debug.Log("There is no objectives assigned, put some pickups under the objective object");
        }

        // activate first PickUp objects
      //  pickups[pickupsCollected].GetComponent<MeshRenderer>().material = activePickUp;
     //   pickups[pickupsCollected].GetComponent<PickUp>().ActivatePickUp();
    }

    public void NextPickUp()
    {
        pickupsCollected++;
        count = count + 1;
        countElementsText.text = "Count: " + count.ToString();

        if (pickupsCollected == pickups.Count)
        {
            finishText.text = "You Finished!";
        }

      /*  if (pickupsCollected == pickups.Count - 1)
        {
            pickups[pickupsCollected].GetComponent<MeshRenderer>().material = finalPickUp;
        }
        else
        {
            pickups[pickupsCollected].GetComponent<MeshRenderer>().material = activePickUp;
        }
        pickups[pickupsCollected].GetComponent<PickUp>().ActivatePickUp();*/

    }

}
