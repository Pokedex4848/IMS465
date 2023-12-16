using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerScene : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerStay(Collider other)
    {
        SceneManager.LoadScene(sceneName);

    }
}
