using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponView _view;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _container;

    private void Start(){
        for(int i = 0; i < _weapons.Count; i++){
            AddItem(_weapons[i]);
            Debug.Log(_weapons[i].IsBuyed);
        }
    }

    private void AddItem(Weapon weapon){
        WeaponView view = Instantiate(_view,_container.transform);
        view.SellButtonClicked += OnSellButtonClicked;
        view.Render(weapon);        
    }

    private void OnSellButtonClicked(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if(weapon.Price <= _player.Money)
        {
            view.SellButtonClicked -= OnSellButtonClicked;
            weapon.Buy();
            _player.BuyWeapon(weapon);
        }
    }
}


