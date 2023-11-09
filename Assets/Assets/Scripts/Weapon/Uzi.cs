using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private float _delay;
    [SerializeField] private int _amountInQueue;

    private float _elapsedTime;
    private Coroutine _shootWithQueueJob;
    public override void Shoot(Transform shootPoint)
    {
        if(_shootWithQueueJob == null)
        {
            _shootWithQueueJob = StartCoroutine(ShootWithQueue(shootPoint));
        }
    }

    public void Update(){
        _elapsedTime += Time.deltaTime;
    }

    private IEnumerator ShootWithQueue(Transform shootPoint)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        for (int i = 0; i < _amountInQueue; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);

            yield return delay;
        }

        EndCoroutine();
        //int counter = 0;
        //while(counter >= _amountInQueue){
        //    counter++;
        //    Instantiate(Bullet, shootPoint.position, Quaternion.identity);

        //    yield return delay;
        //}
    }

    private void EndCoroutine()
    {
        StopCoroutine(_shootWithQueueJob);
    }
}
