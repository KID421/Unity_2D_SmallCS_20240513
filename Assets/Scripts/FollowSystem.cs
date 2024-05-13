using UnityEngine;

namespace KID
{
    /// <summary>
    /// 跟隨系統
    /// </summary>
    public class FollowSystem : MonoBehaviour
    {
        [Header("跟隨目標")]
        public Transform target;

        [SerializeField, Header("跟隨位移"), Range(-10, 10)]
        private float offsetY;

        private void Update()
        {
            Follow();
        }

        /// <summary>
        /// 跟隨
        /// </summary>
        private void Follow()
        {
            Vector2 targetPosition = target.position;
            targetPosition.y += offsetY;
            transform.position = targetPosition;
        }
    }
}
