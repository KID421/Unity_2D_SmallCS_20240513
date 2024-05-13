using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class HpSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 500)]
        private float hp;
        [SerializeField, Header("圖片血條")]
        protected Image imgHp;
        [SerializeField, Header("碰撞後會受傷的物件名稱")]
        private string damageObjectName;

        private float hpMax;

        private void Awake()
        {
            hpMax = hp;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains(damageObjectName))
            {
                float attack = collision.gameObject.GetComponent<Bullet>().attack;
                Damage(attack);
            }
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">傷害值</param>
        private void Damage(float damage)
        {
            if (hp <= 0) return;
            hp -= damage;
            imgHp.fillAmount = hp / hpMax;
            // print($"<color=#f93>{gameObject.name} 受傷</color>");

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            // print($"<color=#f22>{gameObject.name} 死亡</color>");
        }
    }
}
