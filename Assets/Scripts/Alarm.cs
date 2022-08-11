using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _alarm;
    [SerializeField] private AudioSource _sounds;
    [SerializeField] private float _deltaVolume = 0.05f;
    [SerializeField] private float _waitForSecondsInterval = 0.1f;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _setTargetVolme;

    public void TurnOn()
    {
        _sounds.PlayOneShot(_alarm);
        SetTargetVolume(_maxVolume, _deltaVolume, _waitForSecondsInterval);
    }

    public void TurnOf()
    {
        SetTargetVolume(_minVolume, -_deltaVolume, _waitForSecondsInterval);

        if (_sounds.volume == _minVolume)
        {
            _sounds.Stop();
        }
    }

    public void SetTargetVolume(float targetVolume, float deltaVolume, float waitForSecondsInterval)
    {
        if (_setTargetVolme != null)
        {
            StopCoroutine(_setTargetVolme);
        }

        _setTargetVolme = StartCoroutine(ChangeVolume(targetVolume, deltaVolume, waitForSecondsInterval));
    }

    private IEnumerator ChangeVolume(float targetVolume, float deltaVolume, float waitForSecondsInterval)
    {
        float stepVolume;
        var timeInterval = new WaitForSeconds(waitForSecondsInterval);
        float elepsedTime = 0;

        while (_sounds.volume != targetVolume)
        {
            elepsedTime += Time.deltaTime;
            stepVolume = 1f / deltaVolume * elepsedTime;

            _sounds.volume = stepVolume;

            yield return timeInterval;
        }
    }
}
