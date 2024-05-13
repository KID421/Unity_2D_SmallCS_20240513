using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 距離系統
    /// </summary>
    public class DistanceSystem : MonoBehaviour
    {
        [SerializeField, Header("文字距離")]
        private TMP_Text textDistance;

        private float distanceCurrent;

        private void Awake()
        {
            distanceCurrent = transform.position.x;
            UpdateDistance();
        }

        private void Update()
        {
            UpdateDistance();
        }

        private void UpdateDistance()
        {
            if ( transform.position.x > distanceCurrent)
            {
                distanceCurrent = transform.position.x;
                textDistance.text = $"距離：{distanceCurrent.ToString("F0")} 公尺";
            }
        }
    }
}
