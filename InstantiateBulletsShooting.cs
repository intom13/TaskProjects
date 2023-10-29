using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeWaitShooting;
    [SerealizeField] private Transform _objectToShoot;

    private void Start() 
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        bool IsWork = enabled;
    
        while (isWork)
        {
             var Vector3direction = (_objectToShoot.position - transform.position).normalized;
             var NewBullet = Instantiate(_prefab, transform.position + Vector3direction, Quaternion.identity);

             NewBullet.GetComponent<Rigidbody>().transform.up = Vector3direction;
             NewBullet.GetComponent<Rigidbody>().velocity = Vector3direction * _bulletSpeed;

             yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}