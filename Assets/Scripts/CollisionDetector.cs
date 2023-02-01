using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    private string killCollTag = "Kills";
    private string pointTriggerTag = "Point";
    private string paralyzesCollTag = "Paralyzes";

    [SerializeField]
    private ScoreManager scoreManager;

    private PlayerController moveScript;
    private SoundsHandler soundsHandler;


    private void Start()
    {
        moveScript = GetComponent<PlayerController>();
        soundsHandler = GetComponent<SoundsHandler>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(killCollTag))
            OnDeath();
        else if (collision.gameObject.CompareTag(paralyzesCollTag))
            moveScript.OnColl();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag(pointTriggerTag))
        {
            scoreManager.AddPoint();
            soundsHandler.PlayScorePoint();
            trigger.enabled = false;
        }
    }

    private void OnDeath()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) < scoreManager.GetPoints())
        {
            PlayerPrefs.SetInt("HighScore", scoreManager.GetPoints());
        }

        soundsHandler.PlayGameOver();
        SceneManager.LoadScene("MainMenu");
    }
}
