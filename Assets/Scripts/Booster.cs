using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float _force = 200f;

    private Rigidbody _savedRigidbody;

    private void Boost()
    {
        _savedRigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        _savedRigidbody = other.attachedRigidbody;

        Boost();
    }

    private void OnTriggerExit(Collider other)
    {
        _savedRigidbody = null;
    }
}
