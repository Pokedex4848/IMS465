using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.localPosition -= Vector3.forward * 0.05f;

        if(transform.localPosition.z < -38.7)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 97.3f);
        }
    }
}
