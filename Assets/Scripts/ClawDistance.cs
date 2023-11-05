using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawDistance : MonoBehaviour
{
    public ConfigurableJoint clawJoint;
    public float clawMin, clawMax;
    public float clawStep;
    public GameObject claw;

    private void Start()
    {
        clawJoint.projectionDistance = clawMin;
    }

    // Update is called once per frame
    void Update()
    {
        if (clawJoint.projectionDistance >= clawMin && clawJoint.projectionDistance <= clawMax)
        {
            clawJoint.projectionDistance -= Input.mouseScrollDelta.y * clawStep;
        }

        if (clawJoint.projectionDistance < clawMin)
        {
            clawJoint.projectionDistance = clawMin;
        }
        else if (clawJoint.projectionDistance > clawMax)
        {
            clawJoint.projectionDistance = clawMax;
        }

        if(clawJoint.projectionDistance == clawMin)
        {
            claw.transform.localPosition = new Vector2(0, -clawMin);
        }
    }
}
