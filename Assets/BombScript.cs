using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem explodeEffect;
    
    private void Start() {
        explodeEffect = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Explode();
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }

    private void Explode() {
        explodeEffect.Play();
    }
}
