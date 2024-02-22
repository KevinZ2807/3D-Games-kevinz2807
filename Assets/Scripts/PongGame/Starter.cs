using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private PongGame.GameManager gameManager;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<PongGame.GameManager>();
        animator = GetComponent<Animator>();
    }

    public void StartCountdown() {
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame() {
        gameManager.StartGame();
    }
}
