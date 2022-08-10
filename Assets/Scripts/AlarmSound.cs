using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private AudioClip _alarm;
    [SerializeField] private float _deltaVolume;

    public void StarCorutineTurnOn()
    {
        var turnOnJob = StartCoroutine(TurnOn());
        StopCoroutine(turnOnJob);
    }

    private IEnumerator TurnOn()
    {
        var waitForOneSeconds = new WaitForSeconds(1f);
        _alarmSound.PlayOneShot(_alarm);

        for (float i = 0; i < 1f; i += _deltaVolume)
        {
            _alarmSound.volume = i;
        }

        yield return waitForOneSeconds;
    }
}
