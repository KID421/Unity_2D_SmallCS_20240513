using UnityEngine;

namespace KID
{
    /// <summary>
    /// 控制系統
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 3.5f;
        [SerializeField, Header("爬階梯速度"), Range(0, 10)]
        private float stairSpeed = 2;
        [SerializeField, Header("階梯檢查位移")]
        private Vector3 stairOffset;
        [SerializeField, Header("階梯檢查長度"), Range(0, 3)]
        private float stairLength = 1;
        [SerializeField, Header("階梯圖層")]
        private LayerMask layerStair;

        private Rigidbody2D rig;
        private Animator ani;

        private float h => Input.GetAxis("Horizontal");

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawRay(transform.position + stairOffset, transform.right * stairLength);
        }

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector2(h * moveSpeed, Grivaty());
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
        private float Grivaty()
        {
            float hAbs = Mathf.Abs(h);
            float grivaty = Stairs() && hAbs > 0.8f ? hAbs * stairSpeed : rig.velocity.y;
            return grivaty;
        }
    }
}
