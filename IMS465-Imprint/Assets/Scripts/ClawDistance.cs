using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawDistance : MonoBehaviour
{
    public DistanceJoint2D clawJoint;
    public float clawMin, clawMax;
    public float clawStep;
    public GameObject claw;

    private void Start()
    {
        clawJoint.distance = clawMin;
    }

    // Update is called once per frame
    void Update()
    {
        if (clawJoint.distance >= clawMin && clawJoint.distance <= clawMax)
        {
            clawJoint.distance -= Input.mouseScrollDelta.y * clawStep;
        }

        if (clawJoint.distance < clawMin)
        {
            clawJoint.distance = clawMin;
        }
        else if (clawJoint.distance > clawMax)
        {
            clawJoint.distance = clawMax;
        }

        if(clawJoint.distance == clawMin)
        {
            claw.transform.localPosition = new Vector2(0, -clawMin);
        }
    }
}
