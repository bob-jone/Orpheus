using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "You scored:" + Globals.globalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
