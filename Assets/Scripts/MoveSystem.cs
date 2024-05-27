using UnityEngine;

namespace KID
{
    /// <summary>
    /// 移動系統
    /// </summary>
    public class MoveSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 10)]
        protected float moveSpeed = 3.5f;
        [SerializeField, Header("爬階梯速度"), Range(0, 10)]
        private float stairSpeed = 2;
        [SerializeField, Header("階梯檢查位移")]
        private Vector3 stairOffset;
        [SerializeField, Header("階梯檢查長度"), Range(0, 3)]
        private float stairLength = 1;
        [SerializeField, Header("階梯圖層")]
        private LayerMask layerStair = 1 << 9;

        private Rigidbody2D rig;
        private Animator ani;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawRay(transform.position + stairOffset, transform.right * stairLength);
        }

        protected virtual void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        /// <summary>
        /// 移動
        /// </summary>
        protected void Move(float h)
        {
            rig.velocity = transform.right * h * moveSpeed  + transform.up * Grivaty(h);
            ani.SetFloat(GameManager.parMove, rig.velocity.magnitude);
        }

        /// <summary>
        /// 是否有階梯
        /// </summary>
        /// <returns></returns>
        private bool Stairs()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + stairOffset, transform.right, stairLength, layerStair);
            return hit;
        }

        /// <summary>
        /// 重力
        /// </summary>
        private float Grivaty(float h)
        {
            float hAbs = Mathf.Abs(h);
            float grivaty = Stairs() && hAbs > 0.8f ? hAbs * stairSpeed : rig.velocity.y;
            return grivaty;
        }
    }
}
