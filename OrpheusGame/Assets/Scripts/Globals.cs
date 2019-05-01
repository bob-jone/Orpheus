using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    //creates new instance if one does not yet exist
    public static Globals instance;


    private void Awake()
    {
        if (instance == null)
        {
            //makes instance persist across scenes
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            //deletes copies of global which do not need to exist, so right version is used to get info from
            Destroy(gameObject);
        }
    }
    public static int globalScore;
    public string musicKey = "c_major";
    public static int tempo = 80;
    public static bool playingPerc;
    public static Dictionary<string, int> mostPlayed = new Dictionary<string, int>();
    public bool streamerMode = false;
}
