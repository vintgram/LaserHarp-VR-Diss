using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private LineRenderer lr;
    public AudioClip note;
    bool playAudio1;

    public int position = 0;
    public int samplerate = 44100;
    public float frequency = 440;

    void Start()
    {
        lr = GetComponent<LineRenderer>();

        AudioClip myClip = AudioClip.Create("MySinusoid", samplerate * 2, 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = note;
        //aud.Play();

        //GetComponent<AudioSource>().playOnAwake = false;
        //GetComponent<AudioSource>().clip = note;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;


        
        if (Physics.Raycast(transform.position, transform.up, out hit))
        {        
            if (hit.collider)
            {
                GetComponent<AudioSource>().Play();
                lr.SetPosition(1, hit.point);
               
            }
        }
        else
        {
            lr.SetPosition(1, transform.position + (transform.up * 10));
        }

        /* if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
        }
        else lr.SetPosition(1, new Vector3(0, 0, 19));*/
    }

    void OnAudioRead(float[] data)
    {
        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
            position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        position = newPosition;
    }
}