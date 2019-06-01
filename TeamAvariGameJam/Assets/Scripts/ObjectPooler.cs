using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool //to create multiple pools of objects
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools; //list of pools

    public Dictionary<string, Queue<GameObject>> poolDictionary; //dictionary of pools for other scripts to use

	void Start () {

        poolDictionary = new Dictionary<string, Queue<GameObject>>(); // creating the dictionary on start

        foreach(Pool pool in pools) //for each pool of objects made from Pool class in Pools List
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); //create a queue of game objects
            for(int i = 0; i < pool.size; i++) //for i < size of the pool
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj); //add object to the end of the Queue
            }

            poolDictionary.Add(pool.tag, objectPool); //setting the key value to the tag defined in inspector and setting the queue to the one we just created.
        }
	}

    public GameObject SpawnFromPool(string tag, Vector3 spawnPosition, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist!");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();//pulls first element from tag pool queue. 
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = spawnPosition;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);//add back to the pool.

        return objectToSpawn;//to use the object with the function.
    }

}
