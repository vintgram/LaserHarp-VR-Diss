using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(580, 30, 450);
        transform.eulerAngles = new Vector3(0, 0, 0);
        Camera MyCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.worldCamera = MyCamera;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(580, 30, 450);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
