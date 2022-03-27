using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    internal class ClickSpawner : MonoBehaviour, IPointerClickHandler
    {
        [Serializable]
        private class SpawnObjectDescription
        {
            public GameObject Template;
            public int AvailableInstances;
        }

        [SerializeField] private List<SpawnObjectDescription> _spawnObjectDescriptions;

        public void OnPointerClick(PointerEventData eventData)
        {
            SpawnObjectDescription spawnObjectDescription = 
                _spawnObjectDescriptions.FirstOrDefault(x => x.AvailableInstances > 0);

            if (spawnObjectDescription != null)
            {
                Spawn(spawnObjectDescription, eventData.position);
            }
        }

        private void Spawn(SpawnObjectDescription spawnObjectDescription, Vector2 position)
        {
            Instantiate(spawnObjectDescription.Template, position, Quaternion.identity, transform);
            spawnObjectDescription.AvailableInstances--;
        }
    }
}
