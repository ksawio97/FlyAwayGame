using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIMenu : MonoBehaviour
{
    private VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        Button startButton = root.Q<Button>("Start");
        Button settingsButton = root.Q<Button>("Settings");
        Button stopButton = root.Q<Button>("Exit");

        startButton.clicked += () => SceneManager.LoadScene("Game");
        settingsButton.clicked += () => SceneManager.LoadScene("Settings");
        stopButton.clicked += () => Application.Quit();
    }
}
