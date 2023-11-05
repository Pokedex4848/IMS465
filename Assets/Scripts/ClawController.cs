using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public GameObject drone;
    public GameObject[] claws;
    public GameObject grabOffset;
    public LineRenderer lineRenderer;
    public SphereCollider circleCollider;

    private GameObject grabbedObject;
    private Rigidbody grabbedrb;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Quaternion.LookRotation(drone.transform.position - transform.position).eulerAngles.x + 90, Quaternion.LookRotation(drone.transform.position - transform.position).eulerAngles.y, Quaternion.LookRotation(drone.transform.position - transform.position).eulerAngles.z);

        ClawLineRenderer();

        Grab();
    }

    private void ClawLineRenderer()
    {
        lineRenderer.SetPosition(0, drone.transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void Grab()
    {
        if(Input.GetMouseButton(0))
        {
            ClawRotation(0);
            if(grabbedObject)
            {
                grabbedObject.transform.parent = grabOffset.transform;
                grabbedObject.transform.position = new Vector3(grabOffset.transform.position.x, grabOffset.transform.position.y, 1);
                grabbedObject.transform.rotation = transform.rotation;
                grabbedrb.velocity = Vector2.zero;
                grabbedObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            ClawRotation(15);
            if (grabbedObject)
            {
                grabbedObject.transform.parent = null;
                grabbedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                grabbedObject.GetComponent<BoxCollider>().enabled = true;
                grabbedObject = null;
            }
        }
    }

    public void ClawRotation(float scale)
    {
        claws[0].transform.localRotation = Quaternion.Euler(-scale, 0, scale);
        claws[1].transform.localRotation = Quaternion.Euler(-scale, 0, -scale);
        claws[2].transform.localRotation = Quaternion.Euler(scale, 0, -scale);
        claws[3].transform.localRotation = Quaternion.Euler(scale, 0, scale);
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.CompareTag("Grabbable"))
        {
            if(grabbedObject == null) 
            {
                grabbedObject = collision.gameObject;
                grabbedrb = collision.attachedRigidbody;
            }
        }
    }
}
