using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerForge
{
    public class EPPoolerManager : MonoBehaviour
    {

        [Header("Object Poolers")]
        [Tooltip("The array of Object Poolers.")]
        public EPObjectPoolerScriptableObject[] objectsPooler;

        [Header("Audio Clip Poolers")]
        [Tooltip("The array of Audio Clip Poolers.")]
        public EPAudioPoolerScriptableObject[] audioClipsPooler;

        private static EPObjectPoolerScriptableObject[] _objectsPooler;
        private static EPAudioPoolerScriptableObject[] _audioClipsPooler;

        private static EPPoolerManager easyPoolerManager;
        public static EPPoolerManager Instance
        {
            get
            {
                if (!easyPoolerManager)
                {
                    easyPoolerManager = FindObjectOfType(typeof(EPPoolerManager)) as EPPoolerManager;
                    if (!easyPoolerManager)
                    {
                        Debug.LogError("Create an Empty GameObject and drag this Script on it.");
                    }
                    else
                    {
                        easyPoolerManager.Init();
                    }
                }

                return easyPoolerManager;
            }
        }

        void Init()
        {
        }

        void Awake()
        {
            _objectsPooler = objectsPooler;
            _audioClipsPooler = audioClipsPooler;
        }

        /// <summary>
        /// Return the Object Pooler in the Pooler Manager.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static EPObjectPoolerScriptableObject GetObjectPooler(int index)
        {
            if (index < _objectsPooler.Length) return _objectsPooler[index]; else return null;
        }

        /// <summary>
        /// Return the Audio Clip Pooler in the Pooler Manager.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static EPAudioPoolerScriptableObject GetAudioPooler(int index)
        {
            if (index < _audioClipsPooler.Length) return _audioClipsPooler[index]; else return null;
        }

    }


}
