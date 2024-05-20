using UnityEngine;

namespace KID
{
    /// <summary>
    /// 武器控制
    /// </summary>
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField, Header("中心點")]
        private Transform center;

        private Vector3 mousePoint => new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        private Vector3 mouseWorld => Camera.main.ScreenToWorldPoint(mousePoint);

        private void Update()
        {
            WeaponAngle();
        }

        /// <summary>
        /// 武器角度
        /// </summary>
        private void WeaponAngle()
        {
            center.right = mouseWorld - center.position;
        }
    }
}
