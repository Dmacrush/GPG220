using System;
using UnityEngine;

namespace SoundManager
{
    public class SoundAssets : MonoBehaviour
    {
        private static SoundAssets intance;

        public static SoundAssets i
        {
            get
            {
                if (intance == null)
                {
                    intance = Instantiate(Resources.Load<SoundAssets>("SoundAssets"));
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
            public static float soundDelay;
            
        }
        
        //TODO fix this
        public bool CanPlaySound(SoundManager.Sound sound)
        {
            if (SoundAudioClip.soundDelay < Time.time)
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