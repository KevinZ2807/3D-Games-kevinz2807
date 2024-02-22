using UnityEngine;
using UnityEngine.UI;

namespace PongGame {
    public class GameManager : MonoBehaviour {
        public Text player1_scoreText;
        public Text player2_scoreText;
        public GameObject theBall;
        public Starter starter;
        
        private BallController ballController;

        private bool started = false;

        private int _player1_score = 0;
        private int _player2_score = 0;

        private Vector3 startingPosition;

        void Start() {
            ballController = theBall.GetComponent<BallController>();
            startingPosition = theBall.transform.position;
        }

        void Update() {
            if (started) return;

            if (Input.GetKey(KeyCode.Space)) {
                started = true;
                //ballController.Go();
                starter.StartCountdown();
            }
        }
        public void StartGame() {
            ballController.Go();
        }

        public void Scoring_Player1() {
            Debug.Log("Player1 score!");
            _player1_score++;
            UpdateUI();
            ResetBall();
        }
        public void Scoring_Player2() {
            Debug.Log("Player2 score!");
            _player2_score++;
            UpdateUI();
            ResetBall();
        }

        public void UpdateUI() {
            player1_scoreText.text = _player1_score.ToString();
            player2_scoreText.text = _player2_score.ToString();
        }

        private void ResetBall() {
            ballController.Stop();
            theBall.transform.position = startingPosition;
            //ballController.Go();
            starter.StartCountdown();
        }
        

    }
}
