using UnityEngine;
using System.Collections;

public class FogSystemScript : MonoBehaviour {

    // Use this for initialization
    public bool fogOn = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            fogOn = !fogOn;

            if (fogOn)
            {
                GetComponent<ParticleSystem>().Play();
            }
            else
            {
                GetComponent<ParticleSystem>().Stop();
                GetComponent<ParticleSystem>().Clear();
            }
        }
    }
}
