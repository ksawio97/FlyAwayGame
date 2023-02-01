using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highScoreText;

    private int _score = 0;
    private int highScore
    {
        get
        {
            return PlayerPrefs.GetInt("HighScore");
        }
    }

    void Start()
    {
        scoreText.text = $"{_score} Points";
        highScoreText.text = $"HighScore: {highScore}";
    }

    public void AddPoint()
    {
        scoreText.text = $"{++_score} Points";
    }

    public int GetPoints()
    {
        return _score;
    }
}
