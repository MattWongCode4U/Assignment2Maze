using UnityEngine;
using System.Collections;

public class AIMovementScript : MonoBehaviour {

    GameObject playerobj;
    public float speed = 1.0f;
    public AudioSource music;
    public AudioSource ohBaby;
    public AudioSource mlg;

	// Use this for initialization
	void Start () {
        playerobj = GameObject.FindGameObjectWithTag("Player");
        ohBaby.Stop();
        mlg.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = playerobj.transform.position;
        targetPosition.y = this.transform.position.y;
        this.transform.LookAt(targetPosition);
	}

    void FixedUpdate() {
        moveForward();
    }

    void moveForward() {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ball") {
            ohBaby.Play();
            mlg.Play();
        }
    }
}
