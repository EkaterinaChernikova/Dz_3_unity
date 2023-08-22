using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] private Speaker _speaker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement component) == true)
        {
            _speaker.StartChangeVolume();
        }
    }
}
