using UnityEngine;

[CreateAssetMenu(fileName = "new LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    public string SceneName => _sceneName;
    public LevelData[] AdditiveLevels => _additiveLevels;
    public string LevelName => _levelName;
    public EGameMode GameMode => _gameMode;
    public int Time => _time;


    [SerializeField] private string _sceneName;
    [SerializeField] private LevelData[] _additiveLevels;
    [SerializeField] private string _levelName;
    [SerializeField] private EGameMode _gameMode;
    [SerializeField] private int _time;
}