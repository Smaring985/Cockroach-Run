using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFromGun : MonoBehaviour
{
    [SerializeField] float _forceFire;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _point;
    [SerializeField] float _speedRebound;
    [SerializeField] float _reloadRebound;
    [SerializeField] bool _rebound;
    public bool m_rebound {  get { return _rebound; } set { _rebound = value; } }
    [SerializeField] Vector3 _direction;
    [SerializeField] CharacterController _characterController;
 



    

    private void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            Shoot();
     
        }

        if (_rebound)
        {
            Rebound();
            StartCoroutine(nameof(_reboundReload));
        }
    }
    
        private void Rebound()
        {
            _direction = transform.forward;
            _characterController.Move(_direction * _speedRebound * Time.deltaTime);

        }

        public IEnumerator _reboundReload()
        {
            yield return new WaitForSeconds(_reloadRebound);
            _rebound = false;
        }
    
    private void Shoot()
    {
        GameObject _bulletCreate = Instantiate(_bullet, _point.position, Quaternion.identity);  
        _bulletCreate.GetComponent<Rigidbody>().AddForce(_point.forward * _forceFire, ForceMode.Impulse);
    }
}
