using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraCinematicScript : MonoBehaviour
{
    public new GameObject camera;
    void Start()
    {
        StartCoroutine(MoveCamera());
    }
    
    IEnumerator MoveCamera()
    {
        for (int i = 0; i < 120; i++)
        {
            // move camera with direction
            camera.transform.position += new Vector3(0, -0.05f, 0);
            yield return new WaitForSeconds(0.1f);
        }
        // go to next scene after 1 seconds
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room-2");

    }
}
