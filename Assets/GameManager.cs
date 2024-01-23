using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance; // Singleton
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;


    private void Start() {
        instance = this;
    }

    public void IncreaseScore(int point) {
        score += point;
        scoreText.text = "Score: " + score.ToString();
    }
}
