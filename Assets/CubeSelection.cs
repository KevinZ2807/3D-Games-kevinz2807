using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeSelection : MonoBehaviour
{
    [SerializeField] private Renderer render;
    [SerializeField] private GameObject player;
    [SerializeField] private string sceneName;
    private Color baseColor;
    private float minDistance = 5f;
    
    void Start()
    {
        render = GetComponent<Renderer>();
        baseColor = render.material.color;
    }

    void OnMouseOver() {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= minDistance) {
            render.material.color = baseColor;
            return;
        }
        render.material.color = Color.green;
    }

    void OnMouseExit() {
        render.material.color = baseColor;
    }

    void OnMouseDown() {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= minDistance) {
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
