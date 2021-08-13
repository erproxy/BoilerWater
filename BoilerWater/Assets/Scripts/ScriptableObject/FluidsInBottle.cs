using UnityEngine;


    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Fluids In Bottle", order = 1)]
    public class FluidsInBottle : ScriptableObject
    {
        
        [SerializeField] private int maxFluids;
        public float MaxFluids
        {
            get
            {
                return maxFluids;
            }
        }
        
    }
