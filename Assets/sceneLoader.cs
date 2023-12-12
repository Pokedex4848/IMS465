using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneLoader : MonoBehaviour
{
    public string sceneLoad;
    private void OnTriggerEnter(Collider other)
    {
        loadScene(sceneLoad);
    }
    public void loadScene(string sceneInput)
    {
        SceneManager.LoadScene(sceneInput);
    }

}
