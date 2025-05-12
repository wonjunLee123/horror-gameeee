using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool playerInRange = false;
    private PlayerController2D playerController;

    void Start()
    {
        // 이미 열쇠를 가지고 있으면 자기 자신 제거
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
            Destroy(gameObject); // 키 오브젝트 제거
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