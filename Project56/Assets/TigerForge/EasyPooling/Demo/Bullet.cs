using UnityEngine;

/*
 * BULLET 
 * This demo Script moves the bullet forwards and disactivates it after some seconds.
 */

public class Bullet : MonoBehaviour
{

    [Header("Configuration")]

    [Tooltip("The speed of the bullet.")]
    public float speed = 1;

    [Tooltip("The bullet is destroyed (deactivated) after the specified seconds.")]
    public float destroyDelay = 4f;

    // Because the Pooling System activate/deactivate objects, I need to use OnEnable Unity event to start the Invoke method.
    // I will use this event also if I need to do something when this bullet will be reused.
    void OnEnable()
    {
        // Deactivate this bullet after the specified seconds.
        Invoke("Deactivate", destroyDelay);
    }

    // Update is called once per frame...
    void Update()
    {
        // Move the bullet forwards.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Deactivate()
    {
        // Deactivate this bullet.
        gameObject.SetActive(false);
    }

}
