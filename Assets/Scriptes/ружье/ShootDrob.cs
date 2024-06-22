using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDrob : MonoBehaviour
{

    [SerializeField] Transform _transform;

    [SerializeField] LayerMask _enemy;

    [SerializeField] float _rayDistance;
    
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool shot = Physics.Raycast(_transform.position, Vector3.forward, _rayDistance, _enemy);

            if (shot)
            {
                Debug.Log("оноюк");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_transform.position, Vector3.forward * _rayDistance);
    }
}
