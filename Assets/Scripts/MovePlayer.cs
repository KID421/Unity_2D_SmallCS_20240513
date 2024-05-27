using UnityEngine;

namespace KID
{
    /// <summary>
    /// 移動系統：玩家
    /// </summary>
    public class MovePlayer : MoveSystem
    {
        private float h => Input.GetAxis("Horizontal");

        private void Update()
        {
            Move(h);
        }
    }
}
