using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scr_Laser : MonoBehaviour
{
    //Variables for the colour pickers and material
    public FlexibleColorPicker laserfcp;
    public FlexibleColorPicker projectorfcp;
    public Material material;

    //Length and width of the laser
    public int Distance = 50;
    public float width = 0.02f;

    //A light which is added to the hit point
    private GameObject ColisionLight;
    private Vector3 lightPos;
    //The synth from the synth script and an audio source.
    private Synth synth;
    private AudioSource audioSource;


    void Start()
    {     
        audioSource = gameObject.AddComponent<AudioSource>(); //Add an audio source which will output audio
        audioSource.playOnAwake = false; //Make sure audio doens't play when a projector is added
        synth = GetComponent<Synth>(); //Get the synth from the synth script

    Laserbeam();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the line renderer and material of projector to allow for the customization of colour
        GetComponent<Renderer>().material.color = projectorfcp.color;
        GetComponent<LineRenderer>().startColor = laserfcp.color;
        GetComponent<LineRenderer>().endColor = laserfcp.color;

        Vector3 LaserEnd = transform.position + transform.up * Distance; //The length of the laser
        RaycastHit hit; //Define a raycast hit to find 
        if (Physics.Raycast(transform.position, transform.up, out hit, Distance)) //If statement to see if the raycast has been hit
        {

            //Adjust the size of the line renderer based on the hit position
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            ColisionLight.transform.position = (hit.point - lightPos); //adjust the location of the light
           
            synth.gain = synth.volume; //Set the gain / volume of the synth

            if (audioSource.isPlaying) return; //Have an if statement to fix a bug
            audioSource.Play();//Play the synth when collided with an object           
        }
        else
        {
            //make the line renderer the max length and add a light to the end point
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, LaserEnd);
            ColisionLight.transform.position = LaserEnd;
            audioSource.Stop(); //Make sure the synth does not play when the laser has no collision
        }
    }

    private void Laserbeam()
    {      
        //Add a line renderer to the object
        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.material = material;
        lr.startWidth = width;
        lr.positionCount = 2;

        CollisionLight(); //Add a collision light
    }

    private void CollisionLight()
    {
        //End Point Colission Light settings
        ColisionLight = new GameObject();
        ColisionLight.AddComponent<Light>();
        ColisionLight.GetComponent<Light>().intensity = 20;
        ColisionLight.GetComponent<Light>().bounceIntensity = 20;
        ColisionLight.GetComponent<Light>().range = width * 2;
        ColisionLight.GetComponent<Light>().color = laserfcp.color;
        lightPos = new Vector3(0, 0, width);
    }  
}
