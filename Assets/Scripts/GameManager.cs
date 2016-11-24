using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // Maze
    public Maze mazePrefab;
    private Maze mazeInstance;
    // Player
    public PlayerMovement playerPrefab;
    private PlayerMovement playerInstance;
    // AI
    public AIMovementScript aiPrefab;
    private AIMovementScript aiInstance;
    public Material daySkybox, nightSkybox;
    private float night = 0.25f;
    private float day = 1.0f;
    private Renderer[] _renderers;
    //Audio
    public AudioClip clip1;
    public AudioClip clip2;

	// Use this for initialization
	void Start () {
        StartCoroutine(BeginGame());
	}
	
	// Update is called once per frame
	void Update () {
        if (    Input.GetKeyDown(KeyCode.Home) 
            ||  Input.GetKeyDown(KeyCode.JoystickButton7)
            ||  Input.touchCount > 2
            ||  Input.GetKey(KeyCode.R)) {
            RespawnPlayer();
            RespawnAI();
        }

        //Play / Stop the background music on the AI
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (aiInstance.GetComponent<AudioSource>().isPlaying){
                aiInstance.GetComponent<AudioSource>().Stop();
            } else {
                aiInstance.GetComponent<AudioSource>().Play();
            }
        }
	}

    IEnumerator BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.transform.parent = this.transform;
        yield return StartCoroutine(mazeInstance.Generate());
        GameObject.Find("LoadingCamera").SetActive(false);
        GameObject.Find("LoadingImage").SetActive(false);
        SpawnPlayer();
        SpawnAI();
        SetLighting(PlayerPrefs.GetInt("lighting"));
    }

    void SetLighting(int lighting) {
        // Debug.Log("lighting set to:" + lighting);
        float chosenTime = 0;
        if(lighting == 0) {
            chosenTime = day;
            aiInstance.GetComponent<AudioSource>().clip = clip1;
            Debug.Log("Audio from ai: " + aiInstance.GetComponent<AudioSource>().clip.name);
            aiInstance.GetComponent<AudioSource>().Play();
        } else if(lighting == 1) {
            chosenTime = night;
            aiInstance.GetComponent<AudioSource>().clip = clip2;
            Debug.Log("Audio from ai: " + aiInstance.GetComponent<AudioSource>().clip.name);
            aiInstance.GetComponent<AudioSource>().Play();
        }
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject wall in walls)
        {
            _renderers = wall.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in _renderers)
            {
                renderer.material.SetFloat("_AmbientLighIntensity", chosenTime);
            }
        }
    }

    void SetSkybox(int lighting) {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        if(lighting == 0) {
            // day
            cam.GetComponent<Skybox>().material = daySkybox;
        } else if(lighting == 1) {
            // night
            cam.GetComponent<Skybox>().material = nightSkybox;
        }
    }

    void RestartGame() {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
		BeginGame();
    }

    void SpawnPlayer() {
        playerInstance = Instantiate(playerPrefab) as PlayerMovement;
        playerInstance.transform.parent = this.transform;
        RespawnPlayer();
        SetSkybox(PlayerPrefs.GetInt("lighting"));
    }

    void RespawnPlayer() {
        Vector3 spawn = mazeInstance.GetCell(new IntVector2(0, 0)).transform.position;
        playerInstance.transform.position = new Vector3(spawn.x, playerInstance.transform.position.y, spawn.z);
        playerInstance.ResetView();
    }

    void SpawnAI() {
        aiInstance = Instantiate(aiPrefab) as AIMovementScript;
        aiInstance.transform.parent = this.transform;
        RespawnAI();
    }

    void RespawnAI() {
        Vector3 spawn = mazeInstance.GetCell(new IntVector2(mazeInstance.size.x - 1, mazeInstance.size.z - 1)).transform.position;
        aiInstance.transform.position = new Vector3(spawn.x, aiInstance.transform.position.y, spawn.z);
    }
}
