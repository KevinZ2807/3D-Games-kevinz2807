using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PongGame {
    public class GameManager : MonoBehaviour {
        private int _player1_score = 0;
        private int _player2_score = 0;

        public void Scoring_Player1() {
            Debug.Log("Player1 score!");
            _player1_score++;
        }
        public void Scoring_Player2() {
            Debug.Log("Player2 score!");
            _player2_score++;
        }
    }
}
