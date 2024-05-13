using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 血量系統：敵人
    /// </summary>
    public class HpEnemy : HpSystem
    {
        [SerializeField, Header("畫布血條系統敵人")]
        private GameObject prefabHp;

        private GameObject tempHp;

        private void Awake()
        {
            tempHp = Instantiate(prefabHp);
            tempHp.GetComponent<FollowSystem>().target = transform;
            imgHp = tempHp.transform.Find("圖片血條").GetComponent<Image>();
        }

        protected override void Dead()
        {
            base.Dead();
            Destroy(gameObject);
            Destroy(tempHp);
        }
    }
}
