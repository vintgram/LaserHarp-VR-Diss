using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WristMenu : MonoBehaviour
{
    //Define the variables for the wrist menu
    public GameObject wristUI;
    public bool activeWristUI = true;

    //The projector
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {      
        DisplayWristUI();
    }

    //Function to take the user back to the main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Function to spawn the projector into the scene
    public void SpawnPreFab()
    {

        Instantiate(myPrefab);
    }
    //Checks if the button has been pressed to open or close the menu
    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }



    //Function to open or close the menu
    public void DisplayWristUI()
    {
        if(activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
        }
    }
}
