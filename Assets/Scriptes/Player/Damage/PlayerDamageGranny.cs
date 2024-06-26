using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageGranny : MonoBehaviour, IDamagable
{

    [SerializeField] float _speed;
    public bool _freezing;

    public void GetDamage(int damage)
    {
       // transform.position = Vector3.MoveTowards(transform.position, transform.forward * _speed * Time.deltaTime, _distance);
        transform.position += transform.forward * _speed;
        _freezing = true;
        StartCoroutine(nameof(FreezRegul));
    }
    
    public IEnumerator FreezRegul()
    {
        yield return new WaitForSeconds(4.5f);
        _freezing = false;
    }
}
