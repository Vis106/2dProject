using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _alarm;
    [SerializeField] private AudioSource _sounds;
    [SerializeField] private float _deltaVolume = 0.05f;
    [SerializeField] private float _waitForSecondsInterval = 0.1f;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    public void TurnOn()
    {
        _sounds.PlayOneShot(_alarm);
        StartCoroutine(ChangeVolume(_maxVolume, _deltaVolume, _waitForSecondsInterval));
    }

    public void TurnOf()
    {
        StartCoroutine(ChangeVolume(_minVolume, -_deltaVolume, _waitForSecondsInterval));
        _sounds.Stop();
    }

    private IEnumerator ChangeVolume(float targetVolume, float deltaVolume, float waitForSecondsInterval)
    {
        float stepVolume;
        var timeInterval = new WaitForSeconds(waitForSecondsInterval);
        float elepsedTime=0;

        while (true)
        {
            elepsedTime += Time.deltaTime;
            stepVolume = 1f / deltaVolume * elepsedTime;
            Debug.Log(stepVolume);
            _sounds.volume = stepVolume;

            if (_sounds.volume >= _maxVolume || _sounds.volume <= _minVolume)
                break;

            yield return timeInterval;
        }
    }
}
