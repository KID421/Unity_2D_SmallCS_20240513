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
        [SerializeField, Header("玩家_太空人 - 變形")]
        private Transform player;
        [SerializeField, Header("玩家_太空人 - 渲染")]
        private SpriteRenderer spritePlayer;
        [SerializeField, Header("武器_來福槍 - 渲染")]
        private SpriteRenderer spriteWeapon;

        private Vector3 mousePoint => new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        private Vector3 mouseWorld => Camera.main.ScreenToWorldPoint(mousePoint);
        private bool mouseInRight => mouseWorld.x > player.position.x;

        private void Update()
        {
            WeaponAngle();
            Flip();
        }

        /// <summary>
        /// 武器角度
        /// </summary>
        private void WeaponAngle()
        {
            center.right = mouseWorld - center.position;
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            spritePlayer.flipX = mouseInRight;
            spriteWeapon.flipY = !mouseInRight;
        }
    }
}
