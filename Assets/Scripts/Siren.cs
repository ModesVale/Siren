using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private float _volumeChangeSpeed = 1.0f;
    private bool _isThiefInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            _isThiefInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            _isThiefInside = false;
        }
    }
}
