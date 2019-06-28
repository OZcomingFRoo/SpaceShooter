using UnityEngine;

public class SingletonMusicAudio : MonoBehaviour
{
    [SerializeField]
    static bool staticFuncActicated = false;
    void Awake()
    {
        SetSingleton();
    }

    private static void SetSingleton()
    {
        var audios = FindObjectsOfType<SingletonMusicAudio>();
        if (audios.Length > 1)
        {
            for (int i = 1; i < audios.Length; i++)
            {
                Destroy(audios[i].gameObject);
            }
        }
        DontDestroyOnLoad(audios[0]);
    }
}
