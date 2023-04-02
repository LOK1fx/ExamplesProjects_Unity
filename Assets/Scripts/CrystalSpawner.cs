using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    private SpawnPoint[] _points;

    private void Awake()
    {
        _points = FindObjectsOfType<SpawnPoint>();
    }

    public void Spawn(GameObject prefab)
    {
        var index = Random.Range(0, _points.Length);
        var gameObject = Instantiate(prefab, _points[index].transform.position, _points[index].transform.rotation);
    }
}