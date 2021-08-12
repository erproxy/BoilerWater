using UnityEngine;

namespace Fluid
{
    public class Fluid : IHealth
    {
        
        
        [SerializeField] private float _hp;
        public void TakeDamage(float damage)
        {
            _hp -= damage;

            if (_hp <= 0) 
            {
                //Destroy(gameObject);
            }
        }
    }
}