using System.Collections;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    static public LevelLoader instance;

    [SerializeField] private Animator transtition;
    [SerializeField] private float transitionTime = 1f;

    private void Awake() {
        instance = this;
    }

    public void LoadNextLevel(string levelName) {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel (string levelName) {
        transtition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
