using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    private Coin[] _coins;

    public bool IsAllCoinsCollected { get; private set; }

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in _coins)
            coin.Collected += OnCoinsCollected;
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
            coin.Collected -= OnCoinsCollected;
    }

    private void OnCoinsCollected()
    {
        foreach (var coin in _coins)
            if (coin.IsCollected == false)
                return;

        IsAllCoinsCollected = true;
        Debug.Log("work");
    }
}
