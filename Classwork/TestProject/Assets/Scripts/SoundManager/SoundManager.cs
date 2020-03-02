using System.Collections.Generic;
using UnityEngine;

namespace SoundManager
{
    public static class SoundManager
    {
        //simply add in sound name to enum and add clip to sound assets
        public enum Sound
        {
            meleeAtt,
            rangeAtt,
            die,
            moving,
        }

        
        //simply call SoundManager.Play sound to play desired sound
        public static void PlaySound(Sound sound)
        {
            if (SoundAssets.i.CanPlaySound(sound))
            {
                GameObject soundGameobject = new GameObject("Sound");
                AudioSource audioSource = soundGameobject.AddComponent<AudioSource>();
                audioSource.PlayOneShot(GetAudioClip(sound));
            }
        }
        
        //use this version of the function to spawn in 3D space
        public static void PlaySound(Sound sound, Vector3 position)
        {
            if (SoundAssets.i.CanPlaySound(sound))
            {
                GameObject soundGameobject = new GameObject("Sound");
                soundGameobject.transform.position = position;
                AudioSource audioSource = soundGameobject.AddComponent<AudioSource>();
                audioSource.clip = GetAudioClip(sound);
                audioSource.Play();
            }
        }

        private static AudioClip GetAudioClip(Sound sound)
        {
            foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.soundAudioClipArray)
            {
                if (soundAudioClip.sound == sound)
                {
                    return soundAudioClip.audioClip;
                }
            }

            Debug.LogError("Sound " + sound + " not found");
            return null;
        }
    }
}