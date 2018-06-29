using UnityEngine;
using System.Collections;

public class NavObject : MonoBehaviour
{
    public enum Direction { Left, Right, Straight, Around };

    public bool isArrow;
    public bool hasSound;
    public bool isHaptic;
    public Direction direction;


    void Start()
    {
        if (!isArrow)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (hasSound)
            {
                AudioManager audioManager = FindObjectOfType<AudioManager>();
                switch (direction)
                {
                    case Direction.Left:
                        {
                            audioManager.Play("left");
                            break;
                        }
                    case Direction.Right:
                        {
                            audioManager.Play("right");
                            break;
                        }
                    case Direction.Straight:
                        {
                            audioManager.Play("straight");
                            break;
                        }
                    case Direction.Around:
                        {
                            audioManager.Play("around");
                            break;
                        }

                }

                if (isHaptic)
                {
                    //do something
                }
            }

        }
    }
}
