using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroCondition : MonoBehaviour
    {
        private List<GameObject> pursuers = new List<GameObject>();

        public bool IsTargeted => pursuers.Count > 0;

        public void AddPursuer(GameObject gameObject)
        {
            if (pursuers.Contains(gameObject)) return;

            pursuers.Add(gameObject);
        }

        public void RemovePursuer(GameObject gameObject)
        {
            if (!pursuers.Contains(gameObject)) return;

            pursuers.Remove(gameObject);
        }
    }
}
