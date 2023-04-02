using UnityEngine;

public class TimedCrystal : MonoBehaviour
{
    [SerializeField] private float _disappearTime = 5f;

    private void Update()
    {
        _disappearTime -= Time.deltaTime;

        if (_disappearTime <= 0)
            Destroy(gameObject);
    }
}
