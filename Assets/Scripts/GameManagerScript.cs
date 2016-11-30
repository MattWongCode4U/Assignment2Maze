using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public string winner;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setPvP(int ispvp)
    {
        PlayerPrefs.SetInt("ispvp", ispvp);
    }

    public int getPvP()
    {
        return PlayerPrefs.GetInt("ispvp");
    }
}
