using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTest : MonoBehaviour
{

    public Color colorLaser = Color.green;
    public Material material;

    public int Distance = 50;
    public float width = 0.02f, finalwith = 0.1f;

    private GameObject ColisionLight;
    private Vector3 lightPos;
    


    void Start()
    {
        //End Point Colission
        ColisionLight = new GameObject();
        ColisionLight.AddComponent<Light>();
        ColisionLight.GetComponent<Light>().intensity = 20;
        ColisionLight.GetComponent<Light>().bounceIntensity = 20;
        ColisionLight.GetComponent<Light>().range = finalwith * 2;
        ColisionLight.GetComponent<Light>().color = colorLaser;
        lightPos = new Vector3(0, 0, finalwith);

        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.material = material;
        lr.startColor = colorLaser;
        lr.endColor = colorLaser;
        lr.startWidth = width;
        lr.endWidth = finalwith;
        lr.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LaserEnd = transform.position + transform.up * Distance;
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.up, out hit, Distance))
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            ColisionLight.transform.position = (hit.point - lightPos);
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, LaserEnd);
            ColisionLight.transform.position = LaserEnd;
        }
    }
}
