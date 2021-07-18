using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "PersonType")]
    public class PersonType : ScriptableObject
    {
        public string Name;
        public int Damage;
        public int MaxHealth;
    }
}