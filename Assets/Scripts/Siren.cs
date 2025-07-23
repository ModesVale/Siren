using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private Thief _thief;
    [SerializeField] private AudioSource _siren;
    [SerializeField] private float _volumeChangeSpeed = 1.0f;
    [SerializeField] private float _volumeMax = 1.0f;
    [SerializeField] private float _volumeMin = 0f;

    private Coroutine _sirenStatus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            Debug.Log("IN");
            RestartCorutine(ActivateSiren());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief) && thief == _thief)
        {
            Debug.Log("OUT");
            RestartCorutine(DeactivateSiren());
        }
    }

    private void RestartCorutine(IEnumerator routine)
    {
        if (_sirenStatus != null)
        {
            StopCoroutine(_sirenStatus);
        }

        _sirenStatus = StartCoroutine(routine);
    }

    private IEnumerator ActivateSiren()
    {
        if (!_siren.isPlaying)
        {
            _siren.Play();
        }

        while (_siren.volume < _volumeMax)
        {
            _siren.volume = Mathf.MoveTowards(_siren.volume, _volumeMax, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

    }

    private IEnumerator DeactivateSiren()
    {
        while (_siren.volume > _volumeMin)
        {
            _siren.volume = Mathf.MoveTowards(_siren.volume, _volumeMin, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _siren.Stop();
    }
}
