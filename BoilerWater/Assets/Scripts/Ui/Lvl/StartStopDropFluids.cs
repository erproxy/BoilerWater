using System;
using Bottle;
using Core;
using Unity.VisualScripting;
using UnityEngine;
using Fluid;


namespace Ui.Lvl
{
    public class StartStopDropFluids : MonoBehaviour
    {
        [SerializeField] private GameObject _startB;
        [SerializeField] private GameObject _stopB;
        [SerializeField] private GameObject _barrier1;
        [SerializeField] private GameObject _barrier2;


        /// <summary>
        /// Делегат необходим для того, чтобы по нажатию кнопки стоп, сработал ивент, который передаст данные
        /// из счетчика частиц в ГеймКор и последний выдаст Результат, победа или поражение.
        /// </summary>
        [SerializeField] private GameCore _gameCore;
        public delegate void StartStop(GameCore _gameCore);
        public StartStop StopWatterDrop;


        public void OnStart()
        {
            _barrier1.SetActive(false);
            _barrier2.SetActive(false);
            _stopB.SetActive(true);
            _startB.SetActive(false);
        }

        public void OnStop()
        {
            StopWatterDrop?.Invoke(_gameCore);
            _barrier1.SetActive(true);
            _barrier2.SetActive(true);
            _stopB.SetActive(false);
        }
        
        
    }
}