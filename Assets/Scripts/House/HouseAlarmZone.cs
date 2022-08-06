using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseAlarmZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _enteredAlarmZone;
    [SerializeField] private UnityEvent _leftAlarmZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enteredAlarmZone?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _leftAlarmZone?.Invoke();
        }
    }
}
