using UnityEngine;

namespace KID
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField, Header("武器系統：敵人")]
        private WeaponEnemy weaponEnemy;
        [SerializeField, Header("開槍間隔"), Range(0, 10)]
        private float fireInterval = 2;

        private Rigidbody2D rig;
        private Animator ani;
        private Transform player;
        private bool isFire;

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
            player = GameObject.Find(GameManager.playerName).transform;
        }

        private void Update()
        {
            Attack();
        }

        /// <summary>
        /// 攻擊
        /// </summary>
        private void Attack()
        {
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
