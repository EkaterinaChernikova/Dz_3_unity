using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Speaker : MonoBehaviour
{
    [SerializeField] private float _changeStep = 0.5f;

    private int _volumeTargetValue = 0;

    private AudioSource _audioSource;

    private Coroutine _changeVolumeCoroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeVolume(int targetValue)
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        do
        {
            _audioSource.volume = Mathf.MoveTowards(
                _audioSource.volume, 
                targetValue, 
                _changeStep * Time.deltaTime);
            yield return null;
        }
        while (_audioSource.volume != targetValue);

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    public void StartChangeVolume()
    {
        _volumeTargetValue = _volumeTargetValue == 0 ? 1 : 0;

        if (_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(_volumeTargetValue));
    }
}