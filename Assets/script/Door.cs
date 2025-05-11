using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnInteraction : MonoBehaviour
{
    public string sceneToLoad; // ��ȯ�� �� �̸�

    private bool isPlayerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("�� ��ȯ ��: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}