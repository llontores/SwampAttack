using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _bulletsIndent;
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, new Vector2(shootPoint.position.x, shootPoint.position.y + _bulletsIndent),Quaternion.identity);
        Instantiate(Bullet, new Vector2(shootPoint.position.x, shootPoint.position.y - _bulletsIndent),Quaternion.identity);
    }
}
