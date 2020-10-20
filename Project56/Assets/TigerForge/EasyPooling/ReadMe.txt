================================
 TIGERFORGE - EASY POOLING v.1.0
================================

Easy Pooling is a lightweight suite of Unity C# Scripts to implement a very easy and efficient Pooling System in your game projects.
All the Scripts have comments to explain what they do and how they work.

The suite has 3 files: 2 ScriptableObject, and 1 MonoBehaviour Script.

The 2 ScriptableObjects activate the TigerForge > EasyPooling voices in the Project panel context menu.
From this menu, you can create Object Poolers and Audio Poolers.
The Object Pooler is designed for pooling GameObjects. Instead, the Audio Pooler manages and plays Audio Clips.

OBJECT POOLER
This Pooler just needs a GameObject reference. Optionally, you can set a number of objects that have to be instantiated on game start.
In your C# Scripts, just create a link to the Pooler and then use GetObject() method to get one or more objects managed by the Pooling System.
There are also other methods to obtain various information.

AUDIO POOLER
This Pooler just needs an Audio Clip reference. Optionally, you can define volume, a start delay and a number of clips that have to be instantiated on game start.
In your C# Scripts, just create a link to the Pooler and then use PlayAudio() method to play the clips managed by the Pooling System.
There are also other methods to obtain various information.

TIGERSOFT NAMESPACE
To avoid class names conflicts, the Easy Pooling classes are inside TigerForge namespace. Just put a "using TigerForge" at the beginning of your C# Scripts.

POOLER MANAGER
The Pooler Manager is a MonoBehaviour Script that can be optionally used to manage your Poolers in a different way.
Basically, using this Script, you don't need to link your Scripts to the Poolers.
Just create an Empty GameObject in your Scene and drag the EPPoolerManager script on it. In the Editor panel, now you have two arrays, one for all your
Object Poolers, and one for your Audio Clip Poolers.
Now, in your C# Scripts you can call directly EPPoolerManager.GetObjectPooler(index) and EPPoolerManager.GetAudioPooler(index) to obtain the Poolers stored in the
2 arrays at index location.

DEMO PROJECTS
Two Demo Scenes are provided to better understand how the Pooling System works and can be used.
The "Demo" folder project shows how to use the two Scriptable Objects.
The "Demo2" folder project shows how to do the same operations using the alternative approach offered by the Pooler Manager Script.

SUPER-EASY TO USE
This is an example of a Players Script for making a Player able to shoot bullets.

using UnityEngine;
using TigerForge;
public class Player : MonoBehaviour
{

    public EPObjectPoolerScriptableObject bulletPooler;
    public EPAudioPoolerScriptableObject audioPooler;

    // Update is called once per frame...
    void Update()
    {
        // If I press the Space Bar...
        if (Input.GetKeyUp(KeyCode.Space))
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