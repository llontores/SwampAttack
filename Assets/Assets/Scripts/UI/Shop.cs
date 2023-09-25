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
        }
    }

    private void AddItem(Weapon weapon){
        WeaponView view = Instantiate(_view,_container.transform);
        view.Render(weapon);        
    }
}
