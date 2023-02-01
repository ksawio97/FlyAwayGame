using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UISettings : MonoBehaviour
{
    private VisualElement root;

    private readonly string[] slidersNames = { "Hit", "Flutter", "Dying", "ScorePoint" };

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        LoadSettings();

        Button goBackButton = root.Q<Button>("GoBack");

        goBackButton.clicked += () => OnLeave();
    }
    private void LoadSettings()
    {
        foreach (string sliderName in slidersNames)
            root.Q<Slider>(sliderName).value = PlayerPrefs.GetFloat(sliderName, 50);
    }
    private void OnLeave()
    {
        SaveSettings();
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveSettings()
    {
        foreach (string sliderName in slidersNames)
            PlayerPrefs.SetFloat(sliderName, root.Q<Slider>(sliderName).value);
    }
}
