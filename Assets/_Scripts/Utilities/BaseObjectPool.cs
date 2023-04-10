using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObjectPool<T> : Singleton<BaseObjectPool<T>> where T : MonoBehaviour
{
    [SerializeField] private T prefab;

    public Queue<T> objectPool = new();

    public T Get()
    {
        if (objectPool.Count == 0)
        {
            AddObjects();
        }

      
        return objectPool.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objectPool.Enqueue(objectToReturn);
    }

    private void AddObjects()
    {
        T newObject = Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objectPool.Enqueue(newObject);
    }

}
