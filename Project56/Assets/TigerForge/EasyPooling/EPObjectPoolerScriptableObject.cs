using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerForge
{
    /// <summary>
    /// Manage the pooling of GameObjects.
    /// </summary>
    [CreateAssetMenu(menuName = "TigerSoft/EasyPooling/ObjectPooler", fileName = "NewObjectPooler")]
    public class EPObjectPoolerScriptableObject : ScriptableObject
    {

        [Header("Poolable GameObject")]

        [Tooltip("Drag here the GameObject you want to manage with the Pooling System.")]
        public GameObject poolableObject;

        [Header("Options")]

        [Tooltip("Instantiate a predefined number of GameObjects when the game starts. If 0 (default) nothing is instantiated. It can be useful if you know the number of object you are going to use.")]
        public int createOnStart = 0;

        private List<GameObject> objectsList = new List<GameObject>();

        // When the game starts...
        void OnEnable()
        {

            // Clear the objectsList variable.
            objectsList = new List<GameObject>();

            // If createOnStart is defined, this number of GameObjects is instantiated.
            if (createOnStart > 0) InitializePool(createOnStart);
        }

        /// <summary>
        /// Get an Object. The Pooling System will decide if picking one available object from the Pool or if instantiating and returning a new one.
        /// </summary>
        public GameObject GetObject()
        {
            // Search through the objectsList if there is an available GameObject to return. If found, the GameObject is activated and returned.
            foreach (GameObject go in objectsList)
            {
                if (go != null && !go.activeInHierarchy)
                {
                    go.SetActive(true);
                    return go;
                }
            }
            
            // If the Pool doesn't contain an available GameObject, the Pooling System creates and returns a new GameObject (and adds it to the Pool).
            GameObject newGo = Instantiate(poolableObject);
            objectsList.Add(newGo);
            return newGo;
        }

        /// <summary>
        /// Return the number of objects inside the Pool. 
        /// </summary>
        /// <returns>
        /// The number of objects inside the Pool.
        /// </returns>
        public int GetPoolSize()
        {
            return objectsList.Count;
        }

        /// <summary>
        /// Return the number of objects that are active in this moment. Note that this number is indicative because it might quickly change.
        /// </summary>
        /// <returns>
        /// The numer of active objects.
        /// </returns>
        public int CountActiveObjects()
        {
            int counter = 0;
            foreach (GameObject go in objectsList)
            {
                // Count if the GameObject exists and is active.
                if (go != null && go.activeInHierarchy) counter++;
            }
            return counter;
        }

        /// <summary>
        /// Remove all the objects from the Pool and phisically destroy them. Use this method with caution.
        /// </summary>
        public void DestroyPool()
        {
            // Destroy each managed object.
            foreach (GameObject go in objectsList)
            {
                if (go != null) Destroy(go);
            }
            // Clear the objectsList.
            objectsList.Clear();
        }

        /// <summary>
        /// Instantiate the specified quantity of GameObjects inside the Pool. All the objects will be managed by the Pooling System.
        /// </summary>
        /// <param name="quantity">
        /// The number of GameObjects to instantiate.
        /// </param>
        public void InitializePool(int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                // Create a new object, disable it and add it to the objectsList collection.
                GameObject go = Instantiate(poolableObject);
                go.SetActive(false);
                objectsList.Add(go);
            }
        }

    }
}


