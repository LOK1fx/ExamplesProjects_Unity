using UnityEngine;

[RequireComponent(typeof(CrystalSpawner))]
public class GameMode : MonoBehaviour
{
    public static GameMode Instance;

    public CrystalSpawner Spawner { get; private set; }
    public bool IsStarted { get; private set; }

    public EGameMode CurrentGameMode;

    [Space]
    [SerializeField] private GameObject _defaultCrystalPrefab;
    [SerializeField] private GameObject _timedCrystalPrefab;

    private float _rawTimer = 0f;
    private int _timer = 0;


    private void Awake()
    {
        Spawner = GetComponent<CrystalSpawner>();

        Instance = this;
    }

    private void Update()
    {
        if (IsStarted)
        {
            _rawTimer += Time.deltaTime;
            _timer = Mathf.FloorToInt(_rawTimer);

            if(_timer % 10 == 0)
            {
                switch (CurrentGameMode)
                {
                    case EGameMode.Default:
                        Spawner.Spawn(_defaultCrystalPrefab);
                        break;
                    case EGameMode.OnTime:
                        Spawner.Spawn(_timedCrystalPrefab);
                        break;
                }

                _rawTimer += 1;
            }
        }

        //var index = Random.Range(0, 2);

        //Debug.Log(index);
    }

    public void OnStartGame()
    {
        IsStarted = true;
    }
}
