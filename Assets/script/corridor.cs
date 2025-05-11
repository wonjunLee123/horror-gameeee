using UnityEngine;

public class SceneAutoChangeTrigger : MonoBehaviour
{
    public string sceneToLoad;

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // 중복 방지
            SceneTransitionManager.Instance.ChangeScene(sceneToLoad);
        }
    }


}
