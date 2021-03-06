using System;
using UnityEngine;
using System.Collections.Generic;
using Core;
using Ui.Lvl;


namespace Bottle
{
    public class FluidCount : MonoBehaviour
    {   
        [Header("Counting Fluids")]
        [SerializeField] private Transform _checkCountPos;
        [SerializeField] private float _rangeCounting;
        [SerializeField] private LayerMask _whatIsSolid;

        [Header("Data")]
        [SerializeField] private FluidsInBottle _fluidsInBottle;
        

        private float _percentFullness;
        private List<Collider2D> _fluidList = new List<Collider2D>();

        public delegate void Fullness(float percentFullness);
        public Fullness PouredWater;
        public Fullness StopWaterDrop;

        private StartStopDropFluids _startStopDropFluids;
        private void Start()
        {
            _startStopDropFluids = GameObject.Find("StartStop").GetComponent<StartStopDropFluids>();
            _startStopDropFluids.StopWatterDrop += StopWatterDrop;
        }

        private void StopWatterDrop(GameCore gameCore)
        {
            StopWaterDrop?.Invoke(_percentFullness);
            _startStopDropFluids.StopWatterDrop -= StopWatterDrop;
        }

        public float PercentFullness()
        {
            Collider2D[] enemies= Physics2D.OverlapCircleAll(_checkCountPos.position,
                _rangeCounting, _whatIsSolid);
            if (enemies != null)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (_fluidList==null)
                    {
                        _fluidList.Add(enemies[i]);
                        continue;
                    }
                    bool canBeCounting=true;
                    
                    foreach (var fluid in _fluidList)
                    {
                        if (fluid==enemies[i])
                        {
                            canBeCounting = false;
                            break;
                        }
                    }

                    if (canBeCounting)
                    {
                        _fluidList.Add(enemies[i]);
                    }
                }
                         
               //   Debug.Log("счетчик "+_fluidList.Count);     
            }
      
            
            return _percentFullness = (_fluidList.Count/_fluidsInBottle.MaxFluids)*100f;
        }

        private void Update()
        {
            PercentFullness();
           // Debug.Log(_percentFullness);
            
            //Создал ивент, если игрок перелил необходимое количество
            if (_percentFullness > 100)
            {
                PouredWater?.Invoke(_percentFullness);
            }
        }
        //хитбокс
        private void OnDrawGizmosSelected(){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_checkCountPos.position, _rangeCounting);
        }
    }
}