using UnityEngine;

namespace Ui.Lvl
{
    public class Curtain : MonoBehaviour
    {

        [SerializeField] private Animator _anim;

        public void OnEndStartAnim()
        {
            gameObject.SetActive(false);
        }
        public void OnEndAnimReset()
        {
            gameObject.SetActive(false);
        }
    }
}