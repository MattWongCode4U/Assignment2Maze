using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // Maze
    public Maze mazePrefab;
    private Maze mazeInstance;

    private float night = 0.5f;
    private float day = 1.0f;
    private Renderer[] _renderers;

	// Use this for initialization
	void Start () {
        BeginGame();
        SetLighting(PlayerPrefs.GetInt("lighting"));
	}
	
	// Update is called once per frame
	void Update () {
        if (    Input.GetKeyDown(KeyCode.Home) 
            ||  Input.GetKeyDown(KeyCode.JoystickButton7)) {
            RestartGame();
        }
	}

    void BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.transform.parent = this.transform;
        StartCoroutine(mazeInstance.Generate());
    }

    void SetLighting(int lighting) {
        // Debug.Log("lighting set to:" + lighting);
        float chosenTime = 0;
        if(lighting == 0) {
            chosenTime = day;
        } else if(lighting == 1) {
            chosenTime = night;
        }
        _renderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in _renderers) {
            renderer.material.SetFloat("_AmbientLighIntensity", chosenTime);
        }
    }

    void RestartGame() {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
		BeginGame();
    }
}
