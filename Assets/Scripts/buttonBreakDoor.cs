using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBreakDoor : MonoBehaviour
{
    public GameObject wallDestroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<pickUpBox>())
        {
            Destroy(gameObject);
            wallDestroy.GetComponent<Animator>().Play("TreeHide");
        }
    }
}
