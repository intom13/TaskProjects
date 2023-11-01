using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var vector3direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vector3direction, Quaternion.identity);

            Rigidbody2D newBulletRb = GetComponent<Rigidbody2D>();

            newBulletRb.transform.up = vector3direction;
            newBulletRb.velocity = vector3direction * _bulletSpeed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
