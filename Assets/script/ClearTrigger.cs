using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ClearTrigger : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text clearText;              // "CLEAR" 텍스트 (TextMeshPro)
    public GameObject nextSceneButton;      // 버튼 오브젝트

    [Header("Scene Settings")]
    public string nextSceneName;            // 이동할 씬 이름

    private GameObject playerObject;        // 현재 플레이어 오브젝트
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
        // 1회만 처리되도록
        if (playerObject != null && playerObject.activeSelf)
        {
            playerObject.SetActive(false); // 플레이어 비활성화

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

    // 버튼에서 호출됨
    public void GoToNextScene()
    {
        if (KeyManager.Instance != null)
            KeyManager.Instance.ResetKey(); // 열쇠 상태 초기화

        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        else
            Debug.LogWarning("이동할 씬 이름이 비어 있습니다.");
    }
}