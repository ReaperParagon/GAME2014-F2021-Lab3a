using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int bulletNumber;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        // BuildBulletPool();
    }

    public void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            AddBullet();
        }
    }

    private void AddBullet()
    {
        var tempBullet = Instantiate(bulletPrefab);
        tempBullet.SetActive(false);
        tempBullet.transform.parent = transform;
        bulletPool.Enqueue(tempBullet);
    }

    public GameObject GetBullet(Vector2 position)
    {
        if (bulletPool.Count < 1)
        {
            AddBullet();
            bulletNumber++;
        }

        var tempBullet = bulletPool.Dequeue();
        tempBullet.transform.position = position;
        tempBullet.SetActive(true);
        return tempBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
