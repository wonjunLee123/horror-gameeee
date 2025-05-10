using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private PlayerController2D playerController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController2D>();
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = null;
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && playerController != null && playerController.IsInteracting())
        {
            Debug.Log("상호작용");
            // 여기서 문 열기, 아이템 줍기 등 구현 가능
        }
    }
}