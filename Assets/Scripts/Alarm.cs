using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private int alarmVolumeChange = -1;
    [SerializeField] private float volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _audioSource;
    private Coroutine alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>() == true)
        {
            StartAlarm();
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
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeChange, volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
        while (_audioSource.volume > 0 && _audioSource.volume < 100);

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    public void StartAlarm()
    {
        alarmVolumeChange *= -1;

        if(alarm != null)
        {
            StopCoroutine(alarm);
        }

        alarm = StartCoroutine(ChangeVolume(alarmVolumeChange));
    }
}
