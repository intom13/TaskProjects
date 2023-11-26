using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShootingCreator : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletCooldown;

    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private Rigidbody2D _newBulletRigidbody;

    private void Start()
    {
        WaitForSeconds _rechargeWaitingTime = new WaitForSeconds(_bulletCooldown);

        var shooting = StartCoroutine(Shooting(_rechargeWaitingTime));
    }

    private IEnumerator Shooting(WaitForSeconds rechargeWaitingTime)
    {
        bool isWork = enabled;

        while (isWork)
        {
            var direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletTemplate, transform.position + direction, Quaternion.identity);

            _newBulletRigidbody.transform.up = direction;
            _newBulletRigidbody.velocity = direction * _bulletSpeed;

            yield return rechargeWaitingTime;
        }
    }
}
