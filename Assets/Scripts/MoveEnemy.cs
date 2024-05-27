using UnityEngine;

namespace KID
{
    /// <summary>
    /// 移動系統：敵人
    /// </summary>
    public class MoveEnemy : MoveSystem
    {
        [SerializeField, Header("停止距離"), Range(0, 50)]
        private float stopDistance = 3.5f;

        private Transform player;

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.Find(GameManager.playerName).transform;
        }

        private void Update()
        {
            TrackPlayer();
            Flip();
        }

        /// <summary>
        /// 追蹤玩家
        /// </summary>
        private void TrackPlayer()
        {
            float distance = Vector2.Distance(transform.position, player.position);

            Move(distance > stopDistance ? moveSpeed : 0);
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            float angle = player.position.x > transform.position.x ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}
