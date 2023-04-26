using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayAnimationsOnKeyPressScript : MonoBehaviour
{
    public PlayableDirector directorComponent; // Timeline
    public Animation animationComponent; // Legacy Animation
    public Animator animatorComponent; // Mecanim Animation

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animationComponent.Play();
            directorComponent.Play();
            animatorComponent.ResetTrigger("Stop");
            animatorComponent.SetTrigger("Start");
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            animationComponent.Stop();
            directorComponent.Stop();
            animatorComponent.ResetTrigger("Start");
            animatorComponent.SetTrigger("Stop");
        }
    }
}
