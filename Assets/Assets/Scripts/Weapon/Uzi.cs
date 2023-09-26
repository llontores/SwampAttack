using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private float _delay;
    [SerializeField] private int _amountInQueue;

    private float _elapsedTime;
    public override void Shoot(Transform shootPoint)
    {
        
    }

    public void Update(){
        _elapsedTime += Time.deltaTime;
    }

    private IEnumerator ShootWithQueue(Transform shootPoint)
    {
        int counter = 0;
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while(counter >= _amountInQueue){
            counter++;
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);

            yield return delay;
        }
    }
}
