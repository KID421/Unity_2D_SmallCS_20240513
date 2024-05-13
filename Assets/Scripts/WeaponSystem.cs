using UnityEngine;

namespace KID
{
    /// <summary>
    /// 武器系統
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("生成子彈位置")]
        private Transform spawnBulletPoint;
        [SerializeField, Header("子彈預製物")]
        private GameObject prefabBullet;
        [SerializeField, Header("子彈發射速度"), Range(0, 5000)]
        private float bulletSpeed = 500;

        protected virtual void Update()
        {

        }

        /// <summary>
        /// 開槍
        /// </summary>
        public virtual void Fire()
        {
            GameObject tempBullet = Instantiate(prefabBullet, spawnBulletPoint.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
        }
    }
}
