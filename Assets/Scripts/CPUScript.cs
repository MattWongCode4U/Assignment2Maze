using UnityEngine;
using System.Collections;

public class CPUScript : MonoBehaviour {
    public GameObject gm;
    public int isPlayerControlled;
    public float speed = 1.0f;
    public bool movingUp = true;

    private GameManagerScript gameManager;

    // Use this for initialization
    void Start () {
        gameManager = gm.GetComponent<GameManagerScript>();
        isPlayerControlled = gameManager.getPvP();
        Debug.Log("isPlayerControlled" + isPlayerControlled);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isPlayerControlled == 1)
        {
            //if (Input.GetKey("up"))
            //{
            //    MoveUp();
            //}

            //else if (Input.GetKey("down"))
            //{
            //    MoveDown();
            //}

            //else if (Input.GetAxis("Vertical2") != 0)
            ////else if (Input.GetAxis("Vertical2") != 1.0f || Input.GetAxis("Vertical2") != -1.0f)
            //{
            //    Debug.Log("Vertical2(): " + Input.GetAxis("Vertical2"));
            //    transform.Translate(0, Input.GetAxis("Vertical2") * speed, 0);
            //}
            Debug.Log("Vertical2():" + Input.GetAxis("VSecondPlayer"));
            transform.Translate(0, Mathf.Round(Input.GetAxis("VSecondPlayer")) * speed, 0);

            //Touch controls
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).position.x > Screen.width / 2)
                {
                    if (Input.GetTouch(i).position.y > Screen.height / 2)
                    {
                        MoveUp();
                    }
                    else if (Input.GetTouch(i).position.y < Screen.height / 2)
                    {
                        MoveDown();
                    }
                }
            }
        }
        else
        {
            if (movingUp)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }

    void MoveUp()
    {
        Vector3 upVec = new Vector3(0.0f, speed, 0.0f);
        transform.Translate(upVec);
    }

    void MoveDown()
    {
        Vector3 downVec = new Vector3(0.0f, -speed, 0.0f);
        transform.Translate(downVec);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            movingUp = !movingUp;
        }
    }
}
