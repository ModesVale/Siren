using System;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    public event Action<bool> ThiefDetectedChanged;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            ThiefDetectedChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            ThiefDetectedChanged?.Invoke(false);
        }
    }
}
