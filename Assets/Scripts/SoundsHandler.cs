using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] sounds;

    private readonly string[] slidersNames = { "Hit", "Flutter", "Dying", "ScorePoint" };

    void Start()
    {
        ApplySettings();
    }

    private void ApplySettings()
    {
        for(int i = 0; i < slidersNames.Length; i++)
        {
            sounds[i].volume = PlayerPrefs.GetFloat(slidersNames[i], 0);
            Debug.Log(PlayerPrefs.GetFloat(slidersNames[i], 0));
        }
    }
    public void PlayHit()
    {
        sounds[0].Play();
    }

    public void PlayFlutter()
    {
        sounds[1].Play();
    }

    public void PlayGameOver()
    {
        sounds[2].Play();
    }

    public void PlayScorePoint()
    {
        sounds[3].Play();
    }
}
