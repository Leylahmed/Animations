using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinManager : MonoBehaviour
{
    public static PlayerCoinManager instance;
    [SerializeField] private PlayerDataSO playerData;

    private void Awake()
    {
        instance = this;
    }

    public bool onBuyButtonPressed()
    {

    }
}
