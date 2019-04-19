using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ChordController : MonoBehaviour
{
    public GameObject ChordImage;
    public GameObject player;
    float width;
    public AudioClip chord1;
    public AudioClip chord2;
    public AudioClip chord3;
    public AudioClip chord4;
    public AudioClip chord5;
    public AudioClip chord6;
    public AudioClip chord7;
    public AudioClip chord8;
    public AudioClip perc1;
    public AudioClip perc2;
    List<AudioClip> listOfChords = new List<AudioClip>();
    public AudioSource chordPlayer;
    public AudioSource percPlayer;

    int indexForChord = 0;
    GameObject initChordImage;

    List<GameObject> chordImageLists;
    void playChord(int index)
    {
        chordPlayer.Stop();
        chordPlayer.clip = listOfChords[index];
        chordPlayer.Play();
    }
    void playPerc()
    {
        percPlayer.Stop();
        percPlayer.Play();
    }
    public void Start()
    {

        listOfChords.Add(chord1);
        listOfChords.Add(chord2);
        listOfChords.Add(chord3);
        listOfChords.Add(chord4);
        listOfChords.Add(chord5);
        listOfChords.Add(chord6);
        listOfChords.Add(chord7);
        listOfChords.Add(chord8);

        chordImageLists = new List<GameObject>();

        initChordImage = Instantiate(ChordImage);
        chordImageLists.Add(initChordImage);
        width = initChordImage.GetComponent<SpriteRenderer>().bounds.size.x*(Globals.tempo/80);

        initChordImage.transform.position = new Vector3(0, 0,0);

    }
    public void Update()
    {
        if(chordImageLists[indexForChord].transform.position.x-width/2 <= player.transform.position.x
        && (chordImageLists[indexForChord].transform.position.x-width/2 > player.transform.position.x - (.3f * (Globals.tempo / 80))))
        {
            int randInt = Random.Range(0, 6);

            playChord(randInt);
            if (Globals.playingPerc)
            {
                playPerc();
            }
        }
        if (chordImageLists.Count > 5)
        {
            indexForChord = 2;
            Destroy(chordImageLists[0]);
            chordImageLists.RemoveAt(0);
        }
        else if (chordImageLists[0].transform.position.x < player.transform.position.x-2*width)
        {
        
            GameObject newChordImage = Instantiate(ChordImage);
            newChordImage.transform.position = 
            new Vector3(chordImageLists[chordImageLists.Count-1].transform.position.x+width, 0,0);

            newChordImage.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f,.1f,.2f);
            chordImageLists.Add(newChordImage);
        }
    }
}