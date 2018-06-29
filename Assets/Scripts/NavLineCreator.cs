using UnityEngine;
using System.Collections;

public class NavLineCreator : MonoBehaviour
{
    public bool drawLine;

	// Use this for initialization
	void Start()
	{
        if (drawLine) {

            Vector3[] positions = new Vector3[this.transform.childCount];
            for (int i = 0; i < this.transform.childCount; i++) {
                positions[i] = this.transform.GetChild(i).position;
            }

            LineRenderer r = GetComponent<LineRenderer>();
            r.positionCount = this.transform.childCount;
            r.SetPositions(positions);

        }
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
