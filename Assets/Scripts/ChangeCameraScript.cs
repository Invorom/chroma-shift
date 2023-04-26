using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChangeCameraScript : MonoBehaviour
{
    public RenderTexture RenderTexture;
    public RenderTexture RedRenderTexture;
    public RenderTexture BlueRenderTexture;
    public RenderTexture GreenRenderTexture;
    public RenderTexture YellowRenderTexture;
    public RenderTexture BlackRenderTexture;
    public GameObject screen;
    
    public void OnClick()
    {
        var screenRenderer = screen.GetComponent<Renderer>();
        if (screenRenderer.material.mainTexture == RenderTexture)
        {
            screenRenderer.material.mainTexture = RedRenderTexture;
        }
        else if (screenRenderer.material.mainTexture == RedRenderTexture)
        {
            screenRenderer.material.mainTexture = BlueRenderTexture;
        }
        else if (screenRenderer.material.mainTexture == BlueRenderTexture)
        {
            screenRenderer.material.mainTexture = GreenRenderTexture;
        }
        else if (screenRenderer.material.mainTexture == GreenRenderTexture)
        {
            screenRenderer.material.mainTexture = YellowRenderTexture;
        }
        else if (screenRenderer.material.mainTexture == YellowRenderTexture)
        {
            screenRenderer.material.mainTexture = BlackRenderTexture;
        }
        else if (screenRenderer.material.mainTexture == BlackRenderTexture)
        {
            screenRenderer.material.mainTexture = RenderTexture;
        } 
    }
}
