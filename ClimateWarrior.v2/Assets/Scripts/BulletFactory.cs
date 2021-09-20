using System.Collections;
using UnityEngine;

public class BulletFactory : SingletonMonoBehavior<BulletFactory>
{
    public GameObject m_scrollBullet;
    public int m_maxNumberOfBullet;

    private PrefabPool _bulletPool;
    protected override void OnAwake()
    {
        base.OnAwake();
        _bulletPool = new PrefabPool(m_maxNumberOfBullet,m_scrollBullet);
    }

    public GameObject GetBullet(Vector3 position)
    {
        GameObject bullet = _bulletPool.Get();
        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.identity;
        if (bullet.transform.parent != transform)
        {
            bullet.transform.parent = transform;
        }
        return bullet;
    }

    public void CollectBullet(GameObject bullet)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        _bulletPool.Collect(bullet);
    }
}