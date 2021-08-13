using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ui.Lvl
{

    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;


        public void OnEndAnim()
        {
            _menu.SetActive(true);
        }

    }
}