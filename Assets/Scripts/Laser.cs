using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //public GameObject laserPrefab;
    //public GameObject projector;
    //public Vector3 collision = Vector3.zero;
    //private GameObject spawnLaser;

    private LineRenderer lr;

    //public AudioClip note;
    //AudioSource audioSource;

    //[Range(1, 20000)]  //Creates a slider in the inspector
    //public float frequency = 440;

    //public float sampleRate = 44000;

    //float phase = 1;

    AudioSource audioSource;

    private float sampling_frequency = 48000;



    [Range(0f, 1f)]
    public float noiseRatio = 0.5f;

    //for noise part
    [Range(-1f, 1f)]
    public float offset;

    public float cutoffOn = 800;
    public float cutoffOff = 100;

    public bool cutOff;


    private float increment;
    private float phase;

    public float frequency = 440f;
    public float gain = 0.05f;


    System.Random rand = new System.Random();



    // Start is called before the first frame update
    void Start()
    {
        //Add laser to the object
        //spawnLaser = Instantiate(laserPrefab,projector.transform) as GameObject;
        
        
        lr = GetComponent<LineRenderer>();
        //audioSource = GetComponent<AudioSource>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; //force 2D sound       
        audioSource.Stop();
        //audioSource.Stop(); //avoids audiosource from starting to play automatically

        

}

    // Update is called once per frame
    void Update()
    {
        
        //Enable the laser from a menu button
        /*if(Input.)
        {
            EnableLaser();
        }*/

        UpdateLaser();
            

        //Disable a laser from a menu button
        /*if (Input.)
        {
            DisableLaser();
        }*/
    }

    void EnableLaser()
    {
       
    }

    void UpdateLaser()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;



        if (Physics.Raycast(transform.position, transform.up, out hit))
        {
            if (hit.collider)
            {
                print("Hit");

                //Plays the audio
                //audioSource.PlayOneShot(note, 0.7F);

                //audioSource.Play();              
                audioSource.Play();

                lr.SetPosition(1, hit.point);

            }
        }
        else
        {
            lr.SetPosition(1, transform.position + (transform.up * 10));
            audioSource.Stop();
        }
    }

    void DisableLaser()
    {
        //spawnLaser.SetActive(false);
    }

    /*void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            phase += 2 * Mathf.PI * frequency / sampleRate;

            data[i] = Mathf.Sin(phase);

            if (phase >= 2 * Mathf.PI)
            {
                phase -= 2 * Mathf.PI;
            }
        }
    }*/

    void OnAudioFilterRead(float[] data, int channels)
    {
        float tonalPart = 0;
        float noisePart = 0;

        // update increment in case frequency has changed
        increment = frequency * 2f * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i++)
        {

            //noise
            noisePart = noiseRatio * (float)(rand.NextDouble() * 2.0 - 1.0 + offset);

            phase = phase + increment;
            if (phase > 2 * Mathf.PI) phase = 0;


            //tone
            tonalPart = (1f - noiseRatio) * (float)(gain * Mathf.Sin(phase));


            //together
            data[i] = noisePart + tonalPart;

            // if we have stereo, we copy the mono data to each channel
            if (channels == 2)
            {
                data[i + 1] = data[i];
                i++;
            }


        }
    }

        //Creates a sinewave
        public float CreateSine(int timeIndex, float frequency, float sampleRate)
        {
            return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
        }


}
