using UnityEngine;

public class HideCursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}