using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCloud : MonoBehaviour
{
    [SerializeField] bool _stamina;

    [SerializeField] PlayerHP _playerHP;

    private void Awake()
    {
        _playerHP = FindAnyObjectByType<PlayerHP>();
    }

    private void Update()
    {
        StartCoroutine(nameof(DestroyCloud));
    }

    private void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.tag == "Player" && !_stamina)
        {
            _playerHP.GetDamage(1); 
            _stamina = true;
            StartCoroutine(nameof(StaminaRegul));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && _stamina) 
        {
            StartCoroutine(nameof(StaminaRegul));
        }
    }

    private IEnumerator StaminaRegul()
    {
        yield return new WaitForSeconds(0.4f);
        _stamina = false;
    }

    private IEnumerator DestroyCloud()
    {
        yield return new WaitForSeconds(2);
       Destroy(gameObject);
    }

}
