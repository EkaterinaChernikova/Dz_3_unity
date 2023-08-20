using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _audioSource;
    private Coroutine _changeVolumeCoroutine;
    private const float MinimalVolume = 0.0f;
    private const float MaximalVolume = 1.0f;
    private int _volumeChangeDirection = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement component) == true)
        {
            StartChangeVolume();
        }
    }

    private IEnumerator ChangeVolume(int volumeChange)
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        do
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeChange, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
        while (_audioSource.volume > MinimalVolume && _audioSource.volume < MaximalVolume);

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    public void StartChangeVolume()
    {
        _volumeChangeDirection *= -1;

        if(_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(_volumeChangeDirection));
    }
}
