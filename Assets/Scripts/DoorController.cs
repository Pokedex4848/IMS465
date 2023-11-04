using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;

    private ButtonController[] allButtons;
    private ButtonController[] buttonControllers;
    private bool[] buttonsPressed;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        allButtons = FindObjectsByType<ButtonController>(FindObjectsSortMode.None);

        for (int i = 0; i < allButtons.Length; i++)
        {
            if (allButtons[i].gameObject.transform.parent.name.Substring(0, 5).Equals(gameObject.name))
            {
                counter++;
            }
        }

        buttonControllers = new ButtonController[counter];

        for (int i = 0; i < allButtons.Length; i++)
        {
            if (allButtons[i].gameObject.transform.parent.name.Substring(0, 5).Equals(gameObject.name))
            {
                buttonControllers[i] = allButtons[i];
            }
        }

        buttonsPressed = new bool[buttonControllers.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < counter; i++) 
        {
            buttonsPressed[i] = buttonControllers[i].pressed;
        }

        if (buttonsPressed.Count(t => t == true) == buttonsPressed.Length)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }    
    }
}