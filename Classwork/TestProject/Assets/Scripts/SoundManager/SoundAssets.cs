using System;
using UnityEngine;

namespace SoundManager
{
    public class SoundAssets : MonoBehaviour
    {
        private static SoundAssets intance;
        private SoundAudioClip soundAudioClip;

        public void Awake()
        {
            soundAudioClip = new SoundAudioClip();
        }

        public static SoundAssets i
        {
            get
            {
                if (intance == null)
                {
                    intance = (Instantiate(Resources.Load("SoundAssets")) as GameObject)?.GetComponent<SoundAssets>();
                }

                return intance;
            }
        }

        public SoundAudioClip[] soundAudioClipArray;
        
        [Serializable]
        public class SoundAudioClip
        {
            public SoundManager.Sound sound;
            public AudioClip audioClip;
            public float soundDelay;
            
        }
        
        //TODO fix this
        public bool CanPlaySound(SoundManager.Sound sound)
        {
            if (soundAudioClip.soundDelay < Time.time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
    }
}