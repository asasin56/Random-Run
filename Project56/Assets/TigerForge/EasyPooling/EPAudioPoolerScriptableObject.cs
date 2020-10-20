using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerForge
{
    /// <summary>
    /// Manage the pooling of Audio Clips.
    /// </summary>
    [CreateAssetMenu(menuName = "TigerSoft/EasyPooling/AudioPooler", fileName = "NewAudioPooler")]
    public class EPAudioPoolerScriptableObject : ScriptableObject
    {

        [Header("Poolable Audio Clip")]

        [Tooltip("Drag here the Audio file you want to manage with the Pooling System.")]
        public AudioClip poolableAudio;

        [Header("Options")]

        [Tooltip("The volume for this Audio Clip.")]
        public float volume = 1f;

        [Tooltip("The number of seconds to wait before to play this Audio Clip.")]
        public float delay = 0f;

        [Tooltip("Instantiate a predefined number of Audio Clips when the game starts. If 0 (default) nothing is instantiated. It can be useful if you know the number of Clips you are going to use.")]
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
        /// Play an Audio Clip. The Pooling System will decide if picking one available Audio Clip from the Pool or if instantiating and returning a new one.
        /// </summary>
        public AudioSource PlayAudio(Vector3 position)
        {
            // Search through the objectsList if there is an Audio Clip that isn't playing. If found, the Audio Clip is played and returned.
            foreach (GameObject go in objectsList)
            {
                if (go != null && go.activeInHierarchy)
                {
                    AudioSource aSource = go.GetComponent<AudioSource>();
                    go.transform.position = position;
                    if (!aSource.isPlaying)
                    {
                        aSource.PlayDelayed(delay);
                        return aSource;
                    }
                }
            }

            // If the Pool hasn't a playable Audio Clip, the Pooling System creates a new one and adds it to the Pool.

            var clipName = "[TempAudio] " + poolableAudio.name;

            // Create an empty GameObject in the provided position.
            GameObject audioHost = new GameObject(clipName);
            audioHost.transform.position = position;

            // Add an AudioSource component to this GameObject and play it with the current settings.
            AudioSource audioSource = audioHost.AddComponent<AudioSource>() as AudioSource;
            audioSource.clip = poolableAudio;
            audioSource.volume = volume;
            audioSource.PlayDelayed(delay);

            // Add it to the Pool
            objectsList.Add(audioHost);
           
            return audioSource;

        }

        /// <summary>
        /// Return the number of Audio Clips inside the Pool. 
        /// </summary>
        /// <returns>
        /// The number of Audio Clips inside the Pool.
        /// </returns>
        public int GetPoolSize()
        {
            return objectsList.Count;
        }

        /// <summary>
        /// Return the number of Audio Clips that are playing in this moment. Note that this number is indicative because it might quickly change.
        /// </summary>
        /// <returns>
        /// The numer of playing Audio Clips.
        /// </returns>
        public int CountPlayingClips()
        {
            int counter = 0;
            foreach (GameObject go in objectsList)
            {
                // Count if the GameObject exists and is active.
                if (go != null && go.activeInHierarchy)
                {
                    AudioSource aSource = go.GetComponent<AudioSource>();
                    if (aSource.isPlaying) counter++;
                }
            }
            return counter;
        }

        /// <summary>
        /// Remove all the Audio Clips from the Pool and phisically destroy them. Use this method with caution.
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
        /// Instantiate the specified quantity of Audio Clips inside the Pool. All the Clips will be managed by the Pooling System. In this case, Audio Clips aren't played and positioned.
        /// </summary>
        /// <param name="quantity">
        /// The number of GameObjects to instantiate.
        /// </param>
        public void InitializePool(int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                var clipName = "[TempAudio] " + poolableAudio.name;

                // Create an empty GameObject. The position will be set with PlayAudio method.
                GameObject audioHost = new GameObject(clipName);

                // Add an AudioSource component to this GameObject and play it with the current settings.
                AudioSource audioSource = audioHost.AddComponent<AudioSource>() as AudioSource;
                audioSource.clip = poolableAudio;
                audioSource.volume = volume;

                // Add it to the Pool
                objectsList.Add(audioHost);
            }
        }

    }
}

