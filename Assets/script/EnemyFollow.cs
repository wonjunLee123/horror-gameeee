using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float followRange = 10f;
    [SerializeField] private GameObject gameOverUI; // GAME OVER �ؽ�Ʈ�� ��ư ������ UI �г�

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();

        if (gameOverUI != null)
            gameOverUI.SetActive(false); // ���� �� ����
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= followRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player caught. Game Over!");
            other.gameObject.SetActive(false); // �÷��̾� ��Ȱ��ȭ

            if (gameOverUI != null)
                gameOverUI.SetActive(true); // GAME OVER UI ǥ��
        }
    }

    // �� �Լ��� ��ư���� ������
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}