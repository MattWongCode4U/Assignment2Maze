using UnityEngine;
using System.Collections;

public class FogSystemScript : MonoBehaviour {

    // Use this for initialization
    public bool fogOn = true;
    private GameObject ai;

    void Start()
    {
        ai = GameObject.Find("AI Container(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) 
        ||  Input.GetKeyDown(KeyCode.JoystickButton1)) {
            ToggleFog();
        }
    }

    public void ToggleFog() {
            fogOn = !fogOn;
            CheckFog();
    }

    public void CheckFog() {
        if (fogOn) {
            GetComponent<ParticleSystem>().Play();
            //Make music volume lower when fog is on
            ai.GetComponent<AudioSource>().volume = 0.5f;
        }
        else {
            GetComponent<ParticleSystem>().Stop();
            GetComponent<ParticleSystem>().Clear();
            //Return music volume when fog is off
            ai.GetComponent<AudioSource>().volume = 1.0f;
        }
    }
}
