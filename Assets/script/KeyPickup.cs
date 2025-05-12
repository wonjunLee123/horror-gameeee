using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool playerInRange = false;
    private PlayerController2D playerController;

    void Start()
    {
        // �̹� ���踦 ������ ������ �ڱ� �ڽ� ����
        if (KeyManager.Instance != null && KeyManager.Instance.HasKey())
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (playerInRange && playerController != null && playerController.IsInteracting())
        {
            KeyManager.Instance.PickUpKey();
            Destroy(gameObject); // Ű ������Ʈ ����
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