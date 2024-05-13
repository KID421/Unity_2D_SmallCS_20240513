using UnityEngine;

namespace KID
{
    /// <summary>
    /// 音效系統
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioSystem : MonoBehaviour
    {
        public static AudioSystem instance;

        [Header("音效")]
        [SerializeField]
        private AudioClip soundPlayer;

        private AudioSource aud;

        private void Awake()
        {
            instance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="type">音效類型</param>
        /// <param name="min">最小音量</param>
        /// <param name="max">最大音量</param>
        public void PlayeAudio(AudioType type, float min = 0.5f, float max = 1)
        {
            float volume = Random.Range(min, max);
            aud.PlayOneShot(GetAudio(type));
        }

        public AudioClip GetAudio(AudioType audioType)
        {
            return audioType switch
            {
                AudioType.FirePlayer => soundPlayer,
                _ => null
            };
        }
    }
}
