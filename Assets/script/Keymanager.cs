using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }

    private bool hasKey = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetKey(bool value)
    {
        hasKey = value;
    }

    public bool HasKey()
    {
        return hasKey;
    }

    public void ResetKey()
    {
        hasKey = false;
    }

    public void PickUpKey()
    {
        SetKey(true);
    }
}