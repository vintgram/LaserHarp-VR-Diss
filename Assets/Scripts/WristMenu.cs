using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WristMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject projector;

    public GameObject wristUI;
    public bool activeWristUI = true;

    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {

        DisplayWristUI();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SpawnPreFab()
    {
        Instantiate(myPrefab);

    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }

  


    // Update is called once per frame

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
