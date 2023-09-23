using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
    }
}
