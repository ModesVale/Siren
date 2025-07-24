using System;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private Thief _thief;
    [SerializeField] private Siren _siren;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            _siren.SirenTurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            _siren.SirenTurnOff();
        }
    }
}
