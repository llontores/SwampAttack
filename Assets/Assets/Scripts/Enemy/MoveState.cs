using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, Target.transform.position.x, _speed * Time.deltaTime),transform.position.y,0);
    }
}
