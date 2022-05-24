using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRRayInteractor))]

public class InteractorSwitch : MonoBehaviour
{
    
    [SerializeField]private InputActionReference linerayReference = null;
    [SerializeField]private InputActionReference objectReference = null;
    private XRRayInteractor rayInteractor = null;
    private bool isEnabled = false;

    private GameObject[] menus;




    // Start is called before the first frame update
    void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    void Update()
    {
        DetectObject();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        linerayReference.action.started += ToggleRay;
    }

    private void OnDisable()
    {
        linerayReference.action.started -= ToggleRay;      
    }

    private void ToggleRay(InputAction.CallbackContext context)
    {
        isEnabled = !rayInteractor.enabled;
        rayInteractor.enabled = isEnabled ;
        Debug.Log(isEnabled);
    }

    private void ToggleMenu(GameObject menu)
    {
        if (menu.activeSelf)
        {
            Debug.Log("Disable");
            menu.SetActive(false);
        }
        else
        {
            menus = GameObject.FindGameObjectsWithTag("Menus");
            foreach (GameObject Menu in menus)
            {
                Menu.SetActive(false);
            }
            Debug.Log("Enable");
            //menu.SetActive(false);
            menu.SetActive(true);
        }
    }

    private void DetectObject()
    {
        RaycastHit hit;
        GameObject projector;
        GameObject menu;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit) & (objectReference.action.triggered))
        {
            projector = hit.collider.gameObject;
            menu = projector.transform.GetChild(0).gameObject;
            //menu.SetActive(false);

            ToggleMenu(menu);
            
        }

    }
    

}
