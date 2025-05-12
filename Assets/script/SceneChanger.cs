using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2D : MonoBehaviour
{
    [SerializeField] private string targetSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger2D entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Loading scene: " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}