using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpeningZone : MonoBehaviour
{    
    [SerializeField] private UnityEvent _enteredDoorZone;
    [SerializeField] private UnityEvent _leftDoorZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {           
            _enteredDoorZone?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {            
            _leftDoorZone?.Invoke();
        }
    }
}
