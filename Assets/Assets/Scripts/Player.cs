using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _heatlh;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootpoint;

    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private int _currentHealth;
    private Animator _animator;
    
    public int Money { get; private set; }

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Weapon> WeaponChanged;

    private void Start()
    {
        SetWeapon();
        _currentHealth = _heatlh;
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootpoint);
        }
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void ApplyDamage(int _damage)
    {
        _currentHealth -= _damage;
        HealthChanged?.Invoke(_currentHealth, _heatlh);

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon(){
        Debug.Log(_currentWeaponIndex);
        if(_currentWeaponIndex == _weapons.Count - 1)
            _currentWeapon = _weapons[_currentWeaponIndex];
        
        else{
            _currentWeaponIndex++;
            SetWeapon();
        }
    }

    public void PreviousWeapon(){
        if(_currentWeaponIndex == 0)
            _currentWeapon = _weapons[_currentWeaponIndex];
        
        else{
            _currentWeaponIndex--;
            SetWeapon();
        }
    }

    private void SetWeapon(){
        _currentWeapon = _weapons[_currentWeaponIndex];
        WeaponChanged?.Invoke(_currentWeapon);
    }
}
