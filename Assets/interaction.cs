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
        // S Ű�� ���� "����"���� ����
        if (isPlayerInRange && playerController != null && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("��ȣ�ۿ�");
            // ���⿡ ���� ��ȣ�ۿ� �ڵ� �߰�
        }
    }
}