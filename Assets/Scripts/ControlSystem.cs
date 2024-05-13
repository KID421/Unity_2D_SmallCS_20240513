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

        private Rigidbody2D rig;
        private Animator ani;

        private float h => Input.GetAxis("Horizontal");

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            rig.velocity = new Vector2(h * moveSpeed, 0);
            ani.SetFloat(GameManager.parMove, rig.velocity.magnitude);
        }
    }
}
