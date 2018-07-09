using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RealPlayerMove2 : MonoBehaviour
{

    [SerializeField]
    // Transform destination;
    // NavMeshAgent navMeshAgent;
    //  private Rigidbody rb;

    // to display navigation cues
    public Transform arrowHolder;
    private int currentArrowIndex = 0;
    private int numberOfArrows;

    // to show results
    private int count;
    public Text winText;
    public Text countText;

    //private Transform playerTransform;

    //CharacterController charControl;
    public float walkSpeed;


    //  Vector3[] possitions;
    //  int currentPossitionIndex = 0;
    /*
    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }*/

    // to calculate distance travelled
    float distanceTravelled = 0;
    Vector3 lastPosition;

    // to calculate time spent playing
    float playedTime;
    public Text time;

    void Start()
    {
        playedTime = 0;
        lastPosition = transform.position;
      //  Debug.Log("i am at position" + lastPosition);
        count = 0;
        SetCountText();
        time.text = "";
        winText.text = "";
        //rb = GetComponent<Rigidbody>();
        //playerTransform = this.transform;
        UnityEngine.Debug.Log("Starting...");
        /*navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            UnityEngine.Debug.LogError("This NavMeshAgent is not attached to " + gameObject.name);
        }
        else
        {
            possitions = new Vector3[256];
            // InvokeRepeating("DrawArrow", 0, 2);
            //SetDestination();
        }*/

        if (arrowHolder != null)
        {
            numberOfArrows = arrowHolder.childCount;
            Transform currentChild = arrowHolder.GetChild(currentArrowIndex);
            currentChild.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        playedTime += Time.deltaTime;
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
       // Debug.Log("so far i walked " + distanceTravelled);
        lastPosition = transform.position;
        MovePlayer();
        if (playedTime >= 360)
        {
            FinishGame();
        }
    }

    // allowing to move the player using keyboard
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(moveHorizontal * walkSpeed * Time.deltaTime, 0f, moveVertical * walkSpeed * Time.deltaTime);
    }

    // this method defines what happens during collisions
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision happaning with the real player.");
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("Collision tag is Arrow and i am doing some stuff");
            other.gameObject.SetActive(false);

            if (currentArrowIndex < numberOfArrows - 1)
            {
                arrowHolder.GetChild(currentArrowIndex + 1).gameObject.SetActive(true);
                currentArrowIndex++;
            }

        }
        else if (other.CompareTag("Pick Up"))
        {

            Debug.Log("Collision tag is Pick Up and i am doing some stuff");
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 7)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        time.text = "Time played: " + Mathf.RoundToInt(playedTime).ToString();
        winText.text = "You Finished!";
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("ding_sound");
        Debug.Log("my final position is" + lastPosition);
        Debug.Log("i walked" + distanceTravelled);
        Debug.Log("time taken " + Mathf.RoundToInt(playedTime).ToString());
    }
    
}