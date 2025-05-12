using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public string targetSceneName; // �̵��� �� �̸�

    private bool playerInRange = false;
    private PlayerController2D playerController;

    void Update()
    {
        if (playerInRange && playerController != null && playerController.IsInteracting())
        {
            if (KeyManager.Instance != null && KeyManager.Instance.HasKey())
            {
                Debug.Log("���� ���� �� �� �̵�!");
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.Log("���谡 �����ϴ�.");
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