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
        // S 키를 누른 "순간"에만 실행
        if (isPlayerInRange && playerController != null && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("상호작용");
            // 여기에 실제 상호작용 코드 추가
        }
    }
}