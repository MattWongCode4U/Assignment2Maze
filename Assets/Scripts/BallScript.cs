using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {

    public float ballSpeed = 1.0f;
    public float minBallSpeed = 5.0f;

    public GameObject p1;
    public GameObject p2;
    public GameObject maxScoreMsg;
    public GameObject gm;
    private PlayerScore p1text;
    private PlayerScore p2text;
    private MaxPointMessage maxPtMsg;
    private GameManagerScript gameManager;


    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        p1text = p1.GetComponent<PlayerScore>();
        p2text = p2.GetComponent<PlayerScore>();
        maxPtMsg = maxScoreMsg.GetComponent<MaxPointMessage>();
        gameManager = gm.GetComponent<GameManagerScript>();

        int choice = Mathf.RoundToInt(Random.Range(0, 1));
        if(choice == 1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(
                Random.Range(-ballSpeed, -minBallSpeed), 
                Random.Range(-ballSpeed, ballSpeed), 
                0);
        } else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(
                Random.Range(minBallSpeed, ballSpeed),
                Random.Range(-ballSpeed, ballSpeed),
                0);
        }
	}

    // Update is called once per frame
    void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        float xAmt = 0;
        float yAmt = 0;

        if (other.tag == "ScoreBoundary1" || other.tag == "ScoreBoundary2")
        {
            //Ball hits left boundary
            if (other.tag == "ScoreBoundary1")
            {
                xAmt = Random.Range(-ballSpeed, -minBallSpeed);
                yAmt = Random.Range(-ballSpeed, ballSpeed);
                p2text.score++;
            }

            //Ball hits right boundary
            if (other.tag == "ScoreBoundary2")
            {
                xAmt = Random.Range(minBallSpeed, ballSpeed);
                yAmt = Random.Range(-ballSpeed, ballSpeed);
                p1text.score++;
            }

            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = new Vector3(xAmt, yAmt, 0);

            //Check if someone has won
            if (p1text.score == maxPtMsg.maxScore)
            {
                Debug.Log("P1 win");
                gameManager.winner = "Player1";
                SceneManager.LoadScene("EndGame");
            }
            else if (p2text.score == maxPtMsg.maxScore)
            {
                Debug.Log("P2 win");
                gameManager.winner = "Player2";
                SceneManager.LoadScene("EndGame");
            }
        }

    }
}
