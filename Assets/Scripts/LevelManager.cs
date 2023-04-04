using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private LevelData[] _levels;
    private LevelData _loadedLevel;

    private void Awake()
    {
        _levels = Resources.LoadAll<LevelData>("ScriptableObjects/Levels/");

        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string sceneName)
    {
        foreach (var level in _levels)
        {
            if(sceneName == level.SceneName)
            {
                LoadLevel(level);

                break;
            }
        }
    }

    public void LoadLevel(LevelData data)
    {
        var task = SceneManager.LoadSceneAsync(data.SceneName, LoadSceneMode.Single);

        _loadedLevel = data;

        foreach (var level in data.AdditiveLevels)
        {
            SceneManager.LoadSceneAsync(level.SceneName, LoadSceneMode.Additive);
        }

        task.completed += OnLastLevelLoaded;
    }

    private void OnLastLevelLoaded(AsyncOperation operation)
    {
        GameMode.Instance.SetGameMode(_loadedLevel.GameMode);
        GameMode.Instance.OnStartGame();
    }
}
