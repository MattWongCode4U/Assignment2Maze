using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (Input.GetKey("w"))
        //{
        //    MoveUp();
        //}

        //else if (Input.GetKey("s"))
        //{
        //    MoveDown();
        //}

        //else if (Input.GetAxis("Vertical") != 0)
        //{
        //    transform.Translate(0, Mathf.Round(Input.GetAxis("Vertical")) * speed, 0);
        //}
        transform.Translate(0, Mathf.Round(Input.GetAxis("Vertical")) * speed, 0);

        //Touch controls
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).position.x < Screen.width / 2)
            {
                if(Input.GetTouch(i).position.y > Screen.height / 2)
                {
                    MoveUp();
                }else if(Input.GetTouch(i).position.y < Screen.height / 2)
                {
                    MoveDown();
                }
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
}
