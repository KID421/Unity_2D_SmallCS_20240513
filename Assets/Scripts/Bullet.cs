using UnityEngine;

namespace KID
{
    /// <summary>
    /// 子彈
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [Header("子彈攻擊力"), Range(0, 100)]
        public float attack;

        private void Awake()
        {
            Destroy(gameObject, 2);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
