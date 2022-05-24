using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    //Define the variables for the synth
    public double frequency = 440.0; //Tuning of the synth - standard
    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0;

    //Volume settings
    public float gain;
    public float volume = 0.1f;

    //An array to hold all the frequency values
    public float[] frequencies;

    void Start()
    {
        //Create a range of frequencies that equal to an octave.
        frequencies = new float[13];
        frequencies[0] = 440.00f; //A4
        frequencies[1] = 466.16f; //A#4
        frequencies[2] = 493.88f; //B4
        frequencies[3] = 523.25f; //C5
        frequencies[4] = 554.37f; //C#5
        frequencies[5] = 587.33f; //D5
        frequencies[6] = 622.25f; //D#5
        frequencies[7] = 659.25f; //E5
        frequencies[8] = 698.46f; //F5
        frequencies[9] = 739.99f; //F#5
        frequencies[10] = 783.99f; //G5
        frequencies[11] = 830.61f; //G#5
        frequencies[12] = 880.00f; //A5
    }

    //The function creates a sine wave
    void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;

        for (int i = 0; i< data.Length; i += channels)
        {
            phase += increment;
            data[i] = (float)(gain * Mathf.Sin((float)phase));

            if(channels == 2)
            {
                data[i + 1] = data[i];
            }

            if(phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }
        }
    }
}
