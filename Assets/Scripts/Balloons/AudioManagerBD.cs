using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BalloonDarts
{
    public class AudioManagerBD : MonoBehaviour
    {
        private AudioSource pop;
        // Start is called before the first frame update
        void Start()
        {
            GameManager.inst.playSound.AddListener(PopAudio);
            pop = GetComponent<AudioSource>();
            //pop.volume = gameStorage.volume;
        }

        // Update is called once per frame
        void PopAudio()
        {
            pop.Play();
        }
    }
}