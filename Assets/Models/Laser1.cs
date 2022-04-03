using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firePoint;

    public LineRenderer lr;
    public float maximumLength;

    private void Update()
    {
        lr.SetPosition(0, firePoint.transform.position);
    }
}
