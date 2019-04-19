using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NoteHandler : MonoBehaviour
{
    [SerializeField]
    PlayerController pc;

    [SerializeField]
    int currentKeyNumber;
    [SerializeField]
    int lastKeyNumber;
    [SerializeField]
    int lastInterval;
    [SerializeField]
    int currentInterval;
    [SerializeField]
    bool currentIntervalPositive;

    public string inputMode = "octaveASDF";

    // create dictionaries that link a note to it's position on the piano keyboard and vice versa
    Dictionary<int, string> noteDict = new Dictionary<int, string>();
    Dictionary<string, int> reverseNoteDict = new Dictionary<string, int>();

    // create an array of sounds
    public SoundInfo[] sounds;

    // initialize sound array
    private void Awake()
    {
        foreach (SoundInfo s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        currentInstrument = "Clarinet";
        currentKeyNumber = 40;

        noteDict.Add(16, "C2");
        noteDict.Add(17, "C#2");
        noteDict.Add(18, "D2");
        noteDict.Add(19, "D#2");
        noteDict.Add(20, "E2");
        noteDict.Add(21, "F2");
        noteDict.Add(22, "F#2");
        noteDict.Add(23, "G2");
        noteDict.Add(24, "G#2");
        noteDict.Add(25, "A2");
        noteDict.Add(26, "A#2");
        noteDict.Add(27, "B2");
        noteDict.Add(28, "C3");
        noteDict.Add(29, "C#3");
        noteDict.Add(30, "D3");
        noteDict.Add(31, "D#3");
        noteDict.Add(32, "E3");
        noteDict.Add(33, "F3");
        noteDict.Add(34, "F#3");
        noteDict.Add(35, "G3");
        noteDict.Add(36, "G#3");
        noteDict.Add(37, "A3");
        noteDict.Add(38, "A#3");
        noteDict.Add(39, "B3");
        noteDict.Add(40, "C4");
        noteDict.Add(41, "C#4");
        noteDict.Add(42, "D4");
        noteDict.Add(43, "D#4");
        noteDict.Add(44, "E4");
        noteDict.Add(45, "F4");
        noteDict.Add(46, "F#4");
        noteDict.Add(47, "G4");
        noteDict.Add(48, "G#4");
        noteDict.Add(49, "A4");
        noteDict.Add(50, "A#4");
        noteDict.Add(51, "B4");
        noteDict.Add(52, "C5");
        noteDict.Add(53, "C#5");
        noteDict.Add(54, "D5");
        noteDict.Add(55, "D#5");
        noteDict.Add(56, "E5");
        noteDict.Add(57, "F5");
        noteDict.Add(58, "F#5");
        noteDict.Add(59, "G5");
        noteDict.Add(60, "G#5");
        noteDict.Add(61, "A5");
        noteDict.Add(62, "A#5");
        noteDict.Add(63, "B5");
        noteDict.Add(64, "C6");
        noteDict.Add(65, "C#6");
        noteDict.Add(66, "D6");
        noteDict.Add(67, "D#6");
        noteDict.Add(68, "E6");
        noteDict.Add(69, "F6");
        noteDict.Add(70, "F#6");
        noteDict.Add(71, "G6");
        noteDict.Add(72, "G#6");
        noteDict.Add(73, "A6");
        noteDict.Add(74, "A#6");
        noteDict.Add(75, "B6");
        noteDict.Add(76, "C7");

        reverseNoteDict.Add("C2", 16);
        reverseNoteDict.Add("C#2", 17);
        reverseNoteDict.Add("D2", 18);
        reverseNoteDict.Add("D#2", 19);
        reverseNoteDict.Add("E2", 20);
        reverseNoteDict.Add("F2", 21);
        reverseNoteDict.Add("F#2", 22);
        reverseNoteDict.Add("G2", 23);
        reverseNoteDict.Add("G#2", 24);
        reverseNoteDict.Add("A2", 25);
        reverseNoteDict.Add("A#2", 26);
        reverseNoteDict.Add("B2", 27);
        reverseNoteDict.Add("C3", 28);
        reverseNoteDict.Add("C#3", 29);
        reverseNoteDict.Add("D3", 30);
        reverseNoteDict.Add("D#3", 31);
        reverseNoteDict.Add("E3", 32);
        reverseNoteDict.Add("F3", 33);
        reverseNoteDict.Add("F#3", 34);
        reverseNoteDict.Add("G3", 35);
        reverseNoteDict.Add("G#3", 36);
        reverseNoteDict.Add("A3", 37);
        reverseNoteDict.Add("A#3", 38);
        reverseNoteDict.Add("B3", 39);
        reverseNoteDict.Add("C4", 40);
        reverseNoteDict.Add("C#4", 41);
        reverseNoteDict.Add("D4", 42);
        reverseNoteDict.Add("D#4", 43);
        reverseNoteDict.Add("E4", 44);
        reverseNoteDict.Add("F4", 45);
        reverseNoteDict.Add("F#4", 46);
        reverseNoteDict.Add("G4", 47);
        reverseNoteDict.Add("G#4", 48);
        reverseNoteDict.Add("A4", 49);
        reverseNoteDict.Add("A#4", 50);
        reverseNoteDict.Add("B4", 51);
        reverseNoteDict.Add("C5", 52);
        reverseNoteDict.Add("C#5", 53);
        reverseNoteDict.Add("D5", 54);
        reverseNoteDict.Add("D#5", 55);
        reverseNoteDict.Add("E5", 56);
        reverseNoteDict.Add("F5", 57);
        reverseNoteDict.Add("F#5", 58);
        reverseNoteDict.Add("G5", 59);
        reverseNoteDict.Add("G#5", 60);
        reverseNoteDict.Add("A5", 61);
        reverseNoteDict.Add("A#5", 62);
        reverseNoteDict.Add("B5", 63);
        reverseNoteDict.Add("C6", 64);
        reverseNoteDict.Add("C#6", 65);
        reverseNoteDict.Add("D6", 66);
        reverseNoteDict.Add("D#6", 67);
        reverseNoteDict.Add("E6", 68);
        reverseNoteDict.Add("F6", 69);
        reverseNoteDict.Add("F#6", 70);
        reverseNoteDict.Add("G6", 71);
        reverseNoteDict.Add("G#6", 72);
        reverseNoteDict.Add("A6", 73);
        reverseNoteDict.Add("A#6", 74);
        reverseNoteDict.Add("B6", 75);
        reverseNoteDict.Add("C7", 76);
    }

    public string currentInstrument;

    public void PlayNoteAudio(string name)
    {
        SoundInfo s = Array.Find(sounds, SoundInfo => SoundInfo.name == name);
        if (s == null)
        {
            Debug.LogWarning("something went wrong with " + name + " in PlayNoteAudio");
            return;
        }
        s.source.Play();
        currentKeyNumber = s.keyNumber;
    }

    public void PlayNote(int keyNumber,string instrumentType)
    {
        string noteName = noteDict[keyNumber];
        string audioName = noteName + instrumentType;

        PlayNoteAudio(audioName);

    }

    public void StopAllNoteAudio()
    {
        foreach (var sound in sounds)
        {
            sound.source.Stop();
        }
    }

    public void StopSpecificNoteAudio(int keyNumber)
    {
        SoundInfo s = Array.Find(sounds, SoundInfo => SoundInfo.keyNumber == keyNumber);
        if (s == null)
        {
            Debug.LogWarning("something went wrong with " + name + " in StopSpecificNoteAudio");
            return;
        }
        s.source.Stop();
    }

    private void CheckCurrentInterval()
    {
        if (currentKeyNumber >= lastKeyNumber)
        {
            currentIntervalPositive = true;
        }
        else
        {
            currentIntervalPositive = false;
        }
    }

    private void DecideOnJumpOrDash()
    {
        if (currentIntervalPositive && currentKeyNumber != lastKeyNumber)
        {
            pc.Jump();
        }
        if (currentIntervalPositive == false && currentKeyNumber != lastKeyNumber)
        {
            pc.DashDown();
        }
        if (currentKeyNumber == lastKeyNumber)
        {
            Globals.tempo += 2;
        }
    }
    int tempKeyNumberW;
    int tempKeyNumberA;
    int tempKeyNumberS;
    int tempKeyNumberD;
    int tempKeyNumberSpace;
    private void Update()
    {
        lastInterval = (Mathf.Abs(currentKeyNumber - lastKeyNumber));

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inputMode = "octaveASDF";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inputMode = "sequentialWASD";
        }

        if (inputMode == "sequentialWASD")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                tempKeyNumberW = currentKeyNumber + 1;

                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(tempKeyNumberW, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                StopSpecificNoteAudio(tempKeyNumberW);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                tempKeyNumberA = currentKeyNumber - 5;

                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(tempKeyNumberA, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                StopSpecificNoteAudio(tempKeyNumberA);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                tempKeyNumberS = currentKeyNumber - 1;

                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(tempKeyNumberS, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                StopSpecificNoteAudio(tempKeyNumberS);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                tempKeyNumberD = currentKeyNumber + 5;

                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(tempKeyNumberD, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                StopSpecificNoteAudio(tempKeyNumberD);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tempKeyNumberSpace = currentKeyNumber;

                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(tempKeyNumberSpace, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StopSpecificNoteAudio(tempKeyNumberSpace);
            }
        }
        if (inputMode == "octaveASDF")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(40, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                StopSpecificNoteAudio(40);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(42, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                StopSpecificNoteAudio(42);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(44, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                StopSpecificNoteAudio(44);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(45, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                StopSpecificNoteAudio(45);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(47, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                StopSpecificNoteAudio(47);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(49, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                StopSpecificNoteAudio(49);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(51, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                StopSpecificNoteAudio(51);
            }
            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                StopAllNoteAudio();
                lastKeyNumber = currentKeyNumber;
                PlayNote(52, currentInstrument);
                CheckCurrentInterval();
                DecideOnJumpOrDash();
            }
            if (Input.GetKeyUp(KeyCode.Semicolon))
            {
                StopSpecificNoteAudio(52);
            }
        }
    }
}
