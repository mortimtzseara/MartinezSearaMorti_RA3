using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int initialSize = 10;
    private Stack<GameObject> bulletObjects = new Stack<GameObject>();

    void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            bulletObjects.Push(CreateNewBullet());
        }
    }

    private GameObject CreateNewBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform);
        newBullet.GetComponent<Bullet>().bulletPool = this;
        newBullet.SetActive(false);
        return newBullet;
    }
    public GameObject GetObject(Vector3 position)
    {
        GameObject objectToUse;

        if (bulletObjects.Count > 0)
        {
            objectToUse = bulletObjects.Pop();
        }
        else
        {
            objectToUse = CreateNewBullet();
        }

        objectToUse.transform.position = position;
        objectToUse.SetActive(true);
        return objectToUse;
    }
    public void ReturnObject(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        bulletObjects.Push(objectToReturn);
    }
}