using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameMode.Instance.SetGameMode(EGameMode.Default);

            TryStartGame();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            GameMode.Instance.SetGameMode(EGameMode.OnTime);

            TryStartGame();
        }
    }

    private bool TryStartGame()
    {
        if (GameMode.Instance.IsStarted == false)
        {
            GameMode.Instance.OnStartGame();

            return true;
        }

        return false;
    }
}
