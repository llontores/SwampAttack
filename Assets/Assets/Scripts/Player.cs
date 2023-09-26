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
    private int _currentHealth;
    private Animator _animator;
    
    public int Money { get; private set; }

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _currentWeapon = _weapons[0];
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
}
