using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClicked;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClicked);
        _buyButton.onClick.AddListener(TryLockButton);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClicked);
        _buyButton.onClick.RemoveListener(TryLockButton);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = _weapon.Label;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;
    }

    private void TryLockButton()
    {
        if (_weapon.IsBuyed == true)
            _buyButton.interactable = false;
    }

    private void OnButtonClicked()
    {
        SellButtonClicked?.Invoke(_weapon, this);
    }
}
