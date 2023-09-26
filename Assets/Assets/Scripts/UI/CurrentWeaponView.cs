using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _icon;

    private void OnEnable(){
        _player.WeaponChanged += Render;
    }

    private void OnDisable(){
        _player.WeaponChanged -= Render;
    }

    private void Render(Weapon weapon){
        _icon.sprite = weapon.Icon;
    }
}
