using UnityEngine;
using TigerForge;

/*
 * PLAYER 
 * This demo Script allows the player to shoot bullets using the Pooling System.
 */

public class Player : MonoBehaviour
{
    [Header("Configuration")]

    [Tooltip("The Pooler that will manage my bullets.")]
    public EPObjectPoolerScriptableObject bulletPooler;

    [Tooltip("The Pooler that will manage my bullets.")]
    public EPAudioPoolerScriptableObject audioPooler;

    [Tooltip("The keboard key to press for shooting a bullet ('space' by default).")]
    public KeyCode fireKey = KeyCode.Space;

    [Tooltip("The number of bullets to immediately instantiate when the game starts. If 0 (default) nothing is created.")]
    public int bulletsToCreateOnStart = 0;

    // When the game starts...
    void Start()
    {
        // I can instatiate some bullets, so I can use them without creating them.
        // This method can be useful if I already know, more or less, how many bullets I'm going to use.
        if (bulletsToCreateOnStart > 0) bulletPooler.InitializePool(bulletsToCreateOnStart);
    }

    // Update is called once per frame...
    void Update()
    {
        // If I press the fireKey...
        if (Input.GetKeyUp(fireKey))
        {

            // I ask the Pooling System to create or reuse a bullet.
            GameObject myBullet = bulletPooler.GetObject();

            // I put this bullet where the player is located.
            myBullet.transform.position = transform.position;

            // I play the shoot audio fx, locating it in the player position.
            AudioSource myShootAudio = audioPooler.PlayAudio(transform.position);

        }
    }
}
