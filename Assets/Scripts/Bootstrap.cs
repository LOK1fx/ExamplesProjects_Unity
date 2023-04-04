using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("GameMode", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            LevelManager.Instance.LoadLevel("Level01");
    }
}
