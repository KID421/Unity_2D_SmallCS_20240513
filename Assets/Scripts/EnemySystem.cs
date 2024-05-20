using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("停止距離"), Range(0, 50)]
        private float stopDistance = 3.5f;
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 2.5f;
        [SerializeField, Header("武器系統：敵人")]
        private WeaponEnemy weaponEnemy;
        [SerializeField, Header("開槍間隔"), Range(0, 10)]
        private float fireInterval = 2;

        private Rigidbody2D rig;
        private Animator ani;
        private Transform player;
        private bool isFire;

        private float distance => Vector2.Distance(transform.position, player.position);

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
            player = GameObject.Find(GameManager.playerName).transform;
        }

        private void Update()
        {
            Move();
            Attack();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            ani.SetFloat(GameManager.parMove, rig.velocity.magnitude / moveSpeed);
            if (distance <= stopDistance) return;
            rig.velocity = transform.right * -moveSpeed;
        }

        /// <summary>
        /// 攻擊
        /// </summary>
        private void Attack()
        {
            if (!(distance < stopDistance)) return;
            if (isFire) return;

            weaponEnemy.Fire();
            isFire = true;
            Invoke("CanFire", fireInterval);
        }

        /// <summary>
        /// 可以開槍狀態
        /// </summary>
        private void CanFire()
        {
            isFire = false;
        }
    }
}
