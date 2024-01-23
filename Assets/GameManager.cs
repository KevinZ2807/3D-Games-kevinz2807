using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance; // Singleton
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int score = 0;
    private float timeCount = 0f;

    private void Awake() {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
        Application.targetFrameRate = 60;
    }

    private void Start() {
        instance = this;
        NewGame();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("R pressed");
            timeCount = 0f; // Reset time count whenever R is pressed
        }

        // Check if R key is being held down
        if (Input.GetKey(KeyCode.R)) {
            timeCount += Time.deltaTime;
            
        // Check if the key has been held down for 5 seconds
            if (timeCount >= 5.0f) {
                ResetHighScore();
                UpdateHighScore();
                timeCount = 0f; // Reset time count after action is performed
            }
        }

    // Reset the time count when R key is released
        if (Input.GetKeyUp(KeyCode.R)) {
            timeCount = 0f;
        }
    }

    private void NewGame() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int point) {
        score += point;
        scoreText.text = "Score: " + score.ToString();
        UpdateHighScore();
    }

    public void UpdateHighScore() {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High score: " + score.ToString();
        } else {
            highScoreText.text = "High score: " + score.ToString();
        }
    }

    public void ResetHighScore() {
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("HighScore");
    }
}
