using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private float night = 0.5f;
    private float day = 1.0f;
    private Renderer[] _renderers;

	// Use this for initialization
	void Start () {
        int setDay = PlayerPrefs.GetInt("lighting");
        Debug.Log("lighting set to:" + setDay);
        float chosenTime = 0;

        if(setDay == 0)
        {
            chosenTime = day;
        } else if(setDay == 1)
        {
            chosenTime = night;
        }

        _renderers = GetComponentsInChildren<Renderer>();

        foreach(Renderer renderer in _renderers)
        {
            renderer.material.SetFloat("_AmbientLighIntensity", chosenTime);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
