using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem explodeEffect;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Explode();
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }

    private void Explode() {
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
    }
}
