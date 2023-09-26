using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _money.text = "Money :" + _player.Money.ToString();
        _player.MoneyChanged += OnMoneyChanged;
    }
    
    private void OnDisable(){
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int moneyBalance){
        _money.text = "Money :" + moneyBalance.ToString();

    }

}
