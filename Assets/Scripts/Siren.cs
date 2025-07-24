using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _siren;
    [SerializeField] private float _volumeChangeSpeed = 1.0f;
    [SerializeField] private float _volumeMax = 1.0f;
    [SerializeField] private float _volumeMin = 0f;

    private Coroutine _sirenStatus;

    public void SirenTurnOn()
    {    
        RestartCorutine(ActivateSiren(_volumeMax));
    }

    public void SirenTurnOff()
    {
        RestartCorutine(ActivateSiren(_volumeMin));       
    }

    private void RestartCorutine(IEnumerator routine)
    {
        if (_sirenStatus != null)
        {
            StopCoroutine(_sirenStatus);
        }

        _sirenStatus = StartCoroutine(routine);
    }

    private IEnumerator ActivateSiren(float volume)
    {
        if (!_siren.isPlaying)
        {
            _siren.Play();
        }

        while (!Mathf.Approximately(_siren.volume, volume))
        {
            _siren.volume = Mathf.MoveTowards(_siren.volume, volume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (Mathf.Approximately(volume, _volumeMin))
        {
            _siren.Stop();
        }
    }
}
