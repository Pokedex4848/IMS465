using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool pressed = false;

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y <= -1.15f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -1.15f, transform.localPosition.z);
        }
        else if(transform.localPosition.y >= 0.75f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0.75f, transform.localPosition.z);
        }
        
        if(transform.localPosition.y < 0)
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }
}