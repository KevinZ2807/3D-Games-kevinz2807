using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject wholeObject;
    [SerializeField] private GameObject slicedObject;
    [SerializeField] private Rigidbody fruitRb;
    [SerializeField] private Collider fruitCollider;

    private void Start() {
        fruitRb = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
    }

    private void GetSliced(Vector3 direction, Vector3 position, float force) { // To aplly force to push the fruit
        wholeObject.SetActive(false);
        slicedObject.SetActive(true);

        fruitCollider.enabled = false;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        slicedObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = slicedObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices) {
            slice.velocity = fruitRb.velocity; 
            // Push the object fly away
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse); 
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Blade blade = other.GetComponent<Blade>();
            GetSliced(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }
}
