using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnButtonClickScript : MonoBehaviour
{
    public string sceneName;
    public Button button;

    // Start is called before the first frame update
    private void Start()
    {
        button.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}