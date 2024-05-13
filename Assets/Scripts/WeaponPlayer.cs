using UnityEngine;

namespace KID
{
    /// <summary>
    /// 武器系統：玩家
    /// </summary>
    public class WeaponPlayer : WeaponSystem
    {
        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) Fire();
        }

        public override void Fire()
        {
            base.Fire();
            AudioSystem.instance.PlayeAudio(AudioType.FirePlayer, 0.4f, 1.5f);
        }
    }
}
