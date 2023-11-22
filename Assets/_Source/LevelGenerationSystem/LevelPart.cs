using System.Collections.Generic;
using UnityEngine;

namespace LevelGenerationSystem
{
    public class LevelPart : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _obstacles;
        private List<GameObject> _deactivatedObstacles;

        private void Awake()
        {
            _deactivatedObstacles = new List<GameObject>();
        }
       
        public List<GameObject>  Obstacles => _obstacles;
        public List<GameObject>  DeactivatedObstacles => _deactivatedObstacles;

        public void SetObstacleActive(bool isActive, int index)
        {
            if(isActive)
            {
                _obstacles.Add(_deactivatedObstacles[index]);
                _deactivatedObstacles.RemoveAt(index);
            }
            else
            {
                _deactivatedObstacles.Add(_obstacles[index]);
                _obstacles.RemoveAt(index);
            }
        }
    }
}
