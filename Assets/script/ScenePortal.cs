using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public string targetSceneName; // ¿Ãµø«“ æ¿ ¿Ã∏ß

    private bool playerInRange = false;
    private PlayerController2D playerController;

    void Update()
    {
        if (playerInRange && playerController != null && playerController.IsInteracting())
        {
            if (KeyManager.Instance != null && KeyManager.Instance.HasKey())
            {
                Debug.Log("ø≠ºË ¿÷¿Ω °Ê æ¿ ¿Ãµø!");
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.Log("ø≠ºË∞° æ¯Ω¿¥œ¥Ÿ.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController2D>();
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerController = null;
        }
    }
}