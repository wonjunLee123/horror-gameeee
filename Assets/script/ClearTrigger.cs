using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ClearTrigger : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text clearText;              // "CLEAR" �ؽ�Ʈ (TextMeshPro)
    public GameObject nextSceneButton;      // ��ư ������Ʈ

    [Header("Scene Settings")]
    public string nextSceneName;            // �̵��� �� �̸�

    private GameObject playerObject;        // ���� �÷��̾� ������Ʈ
    private PlayerController2D playerController;
    private bool playerInRange = false;

    void Start()
    {
        if (clearText != null)
            clearText.gameObject.SetActive(false);

        if (nextSceneButton != null)
            nextSceneButton.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && playerController != null && playerController.IsInteracting())
        {
            TriggerClear();
        }
    }

    private void TriggerClear()
    {
        // 1ȸ�� ó���ǵ���
        if (playerObject != null && playerObject.activeSelf)
        {
            playerObject.SetActive(false); // �÷��̾� ��Ȱ��ȭ

            if (clearText != null)
                clearText.gameObject.SetActive(true);

            if (nextSceneButton != null)
                nextSceneButton.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerObject = other.gameObject;
            playerController = playerObject.GetComponent<PlayerController2D>();
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

    // ��ư���� ȣ���
    public void GoToNextScene()
    {
        if (KeyManager.Instance != null)
            KeyManager.Instance.ResetKey(); // ���� ���� �ʱ�ȭ

        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        else
            Debug.LogWarning("�̵��� �� �̸��� ��� �ֽ��ϴ�.");
    }
}