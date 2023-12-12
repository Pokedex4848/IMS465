using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxRope : MonoBehaviour
{
    public float setDistance;
    public float distanceRatio = 1;
    PlayerMovement p;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        p = FindObjectOfType<PlayerMovement>();
    }
    public Animator clawAnim;
    float clawCheckTime;
    public GameObject attachedObject;
    public LineRenderer rope;
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("WE ARE COLLIDING");
        if (attachedObject != null)
            return;
        
            if (collision.gameObject.GetComponent<pickUpBox>())
            {
            if (Input.GetMouseButton(0))
            {
                clawCheckTime = Time.realtimeSinceStartup + 0.1f;
                attachedObject = collision.gameObject;
            }
        }
    }
    float mouseDownTime;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && attachedObject != null)
            mouseDownTime = Time.realtimeSinceStartup + 0.1f;
        GetComponent<BoxCollider>().enabled = Time.realtimeSinceStartup > mouseDownTime;
        rope.SetPosition(1, p.transform.position);
        rope.SetPosition(0, transform.position);
        if (attachedObject != null)
            clawAnim.Play("ClawOpen");
        else if (Time.realtimeSinceStartup < clawCheckTime)
            clawAnim.Play("ClawCheck");
        else
            clawAnim.Play("ClawClose");
        if (!Input.GetMouseButton(0))
            attachedObject = null;
        if (attachedObject != null)
        {
            attachedObject.transform.position = transform.position - Vector3.up * 0.3f;
            attachedObject.GetComponent<Rigidbody>().velocity = new Vector3();
        }
        if (Vector3.Distance(transform.position, p.transform.position) > setDistance * distanceRatio)
        {
            Vector3 oldPosition = transform.position;
            transform.position = Vector3.MoveTowards(p.transform.position, transform.position, setDistance * distanceRatio);
            Vector3 newPosition = transform.position;
            transform.position = oldPosition;
            Vector3 vel = (newPosition - oldPosition) / Time.deltaTime / 5;
            GetComponent<Rigidbody>().velocity = vel;
        }
        if (Vector3.Distance(transform.position, p.transform.position) > setDistance * distanceRatio + 1)
        {
            Vector3 oldPosition = transform.position;
            transform.position = Vector3.MoveTowards(p.transform.position, transform.position, setDistance * distanceRatio);
            Vector3 newPosition = transform.position;
            transform.position = oldPosition;
            Vector3 vel = (newPosition - oldPosition) / Time.deltaTime / 2;
            GetComponent<Rigidbody>().velocity = vel;
        }
        if (Vector3.Distance(transform.position, p.transform.position) > setDistance * distanceRatio + 2)
        {
            p.transform.position += (Vector3.MoveTowards(p.transform.position, transform.position, 1) - p.transform.position)*Time.deltaTime*25;
        }
        GetComponent<Rigidbody>().velocity += Physics.gravity / 3;
        setDistance = Mathf.Clamp(setDistance * distanceRatio - Input.mouseScrollDelta.y / 3, 2, 15 * distanceRatio);

    }
}
