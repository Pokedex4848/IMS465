using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRotation : MonoBehaviour
{
    public float hRotation, vRotation;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(-hRotation * Input.GetAxis("Horizontal"), -90, -vRotation * Input.GetAxis("Vertical"));
    }
}
