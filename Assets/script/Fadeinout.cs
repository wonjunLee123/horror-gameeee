using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeDuration = 1f;

    [Header("Loading UI")]
    public GameObject loadingScreen;

    [Header("Cooldown")]
    public float sceneChangeCooldown = 1.5f;
    private bool isTransitioning = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴 방지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isTransitioning = false; // 씬 전환이 끝났다고 판단
    }

    public void ChangeScene(string sceneName)
    {
        if (!isTransitioning)
            StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        isTransitioning = true;

        if (fadeImage != null)
            yield return StartCoroutine(Fade(1)); // Fade Out

        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        yield return new WaitForSeconds(0.3f); // 작은 딜레이

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (loadingScreen != null)
            loadingScreen.SetActive(false);

        if (fadeImage != null)
            yield return StartCoroutine(Fade(0)); // Fade In

        yield return new WaitForSeconds(sceneChangeCooldown);
        isTransitioning = false;
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float timer = 0f;

        while (timer <= fadeDuration)
        {
            float t = timer / fadeDuration;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, targetAlpha);
    }
}