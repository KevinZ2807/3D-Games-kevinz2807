using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Collider bladeCollider;
    [SerializeField] private TrailRenderer bladeTrail;
    private BladeState currentState;
    public Vector3 direction { get; private set;}
    private float minSliceVelocity = 0.01f;

    private enum BladeState {
        Idle,
        Starting,
        Slicing,
        Stopping
    }

    void Start() {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        currentState = BladeState.Idle;
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void Update() {
        switch (currentState) {
            case BladeState.Idle:
                CheckStartSlicing();
                break;
            case BladeState.Starting:
                StartSlicing();
                break;
            case BladeState.Slicing:
                ContinueSlicing();
                break;
            case BladeState.Stopping:
                StopSlicing();
                break;
        }   
    }

    private void OnEnable() {
        StopSlicing();
    }

    private void OnDisable() {
        StopSlicing();
    }
    private void CheckStartSlicing() {
        if (Input.GetMouseButtonDown(0)) {
            currentState = BladeState.Starting;
        }
    }

    private void StartSlicing() {
        SetNewPosition();
        currentState = BladeState.Slicing;
        bladeCollider.enabled = true;
        bladeTrail.Clear();
        bladeTrail.enabled = true;
    }

    private void StopSlicing() {
        currentState = BladeState.Idle;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void ContinueSlicing() {
        if (Input.GetMouseButtonUp(0)) {
            currentState = BladeState.Stopping;
        } else {
            SetNewPosition();

            float velocity = direction.magnitude / Time.deltaTime;
            bladeCollider.enabled = velocity > minSliceVelocity;
        }
    }

    private void SetNewPosition() {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;
        transform.position = newPosition;
    }
}
