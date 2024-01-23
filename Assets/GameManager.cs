using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance; // Singleton
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int score = 0;

    private void Awake() {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
        Application.targetFrameRate = 60;
    }

    private void Start() {
        instance = this;
        NewGame();
    }

    private void NewGame() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int point) {
        score += point;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHighScore() {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High score: " + score.ToString();
        }
    }

    public void ResetHighScore() {
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("HighScore");
    }
}
