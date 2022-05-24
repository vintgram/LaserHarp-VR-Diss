using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch : MonoBehaviour
{
    int index;
    int letterindex;

    public TMP_Text notename;
    private Synth synth;
    private string[] NoteNames;

    // Start is called before the first frame update
    void Start()
    {

        index = 0;
        NoteNames = new string[] { "A4", "A#4/Bb4", "B4", "C5", "C#5/Db5", "D5","D#5/Eb5", "E5", "F5", " F#5/Gb5", "G5", " G#5/Ab5", "A5" };
        letterindex = 0;
        synth = gameObject.GetComponentInParent<Synth>();

    }

    // Update is called once per frame
    void Update()
    {

        if (index >= 12 & letterindex >= 12)
        {
            index = 12;
            letterindex = 12;
        }
        if (index < 0 & letterindex < 0)
        {
            index = 0;
            letterindex = 0;
        }

        if (index == 0 & letterindex == 0)
        {
            synth.frequency = synth.frequencies[0];
            notename.text = NoteNames[0];
        }
    }

    public void Next()
    {
        index += 1;
        letterindex += 1;

        for(int i = 0; i < NoteNames.Length; i++)
        {
            notename.text = NoteNames[letterindex];
        }
        for (int i = 0; i < synth.frequencies.Length; i++)
        {
            synth.frequency = synth.frequencies[index];
        }

        //notename.text = NoteNames[++letterindex];
        //synth.frequency = synth.frequencies[++index];
        //Debug.Log(index);
    }

    public void Previous()
    {
        index -= 1;
        letterindex -= 1;
        for (int i = 0; i < NoteNames.Length; i++)
        {
            notename.text = NoteNames[letterindex];
        }
        for (int i = 0; i < synth.frequencies.Length; i++)
        {
            synth.frequency = synth.frequencies[index];
        }


        //notename.text = NoteNames[--letterindex];
        //synth.frequency = synth.frequencies[--index];

        // Debug.Log(index);
    }
}

//gameObject.GetComponent<Synth>().gain = gameObject.GetComponent<Synth>().volume;
//gameObject.GetComponent<Synth>().frequency = gameObject.GetComponent<Synth>().frequencies[gameObject.GetComponent<Synth>().thisFreq];
//gameObject.GetComponent<Synth>().thisFreq += 1;
//gameObject.GetComponent<Synth>().thisFreq = gameObject.GetComponent<Synth>().thisFreq % gameObject.GetComponent<Synth>().frequencies.Length;