using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnCollision : MonoBehaviour
{

    // trigger to load scene on collision
    
    public string sceneName;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Load scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
