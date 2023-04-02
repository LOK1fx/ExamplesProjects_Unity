using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private const int LEVEL_01 = 1;
    private const int LEVEL_02 = 2;
    private const int GAME_MODE_SCENE = 3;

    private void Start()
    {
        var sceneIndex = Random.Range(LEVEL_01, LEVEL_02 + 1);

        Debug.Log(sceneIndex);

        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(GAME_MODE_SCENE, LoadSceneMode.Additive);
    }
}
