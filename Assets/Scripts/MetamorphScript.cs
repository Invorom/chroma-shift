using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetamorphScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (transform.localScale.x != 0.5f)
            {
                // Modify the player size
                var player = GameObject.FindWithTag("Player");
                var playerTransform = player.transform;
                var playerScale = playerTransform.localScale;
                playerScale.x = 0.5f;
                playerScale.y = 0.5f;
                playerScale.z = 0.5f;
                playerTransform.localScale = playerScale;
            }
            else
            {
                // Modify the player size
                var player = GameObject.FindWithTag("Player");
                var playerTransform = player.transform;
                var playerScale = playerTransform.localScale;
                playerScale.x = 1;
                playerScale.y = 1;
                playerScale.z = 1;
                playerTransform.localScale = playerScale;
            }
        }
    }
}
