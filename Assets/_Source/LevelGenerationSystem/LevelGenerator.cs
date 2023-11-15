using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelGenerationSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _levelParts;
        [SerializeField] private float _partsSpacing;
        [SerializeField] private float _generatedPartsCount;

        private Queue<GameObject> _instantinatedLevelParts;
        private Transform _cameraTransform;
        private Vector3 _lastPartPosition;

        private void Awake()
        {
            _instantinatedLevelParts = new Queue<GameObject>();
            _cameraTransform = Camera.main.transform;
            _lastPartPosition = Vector3.zero;
        }
       
        private void Update()
        {
            CheckPartsDistance();
           
            if (_instantinatedLevelParts.Count < _generatedPartsCount)
            {
                GenerateRandomPart();
            }
        }
       
        private void CheckPartsDistance()
        {
            if(_instantinatedLevelParts.Count == 0) return;
           
            if (_cameraTransform.position.x - _instantinatedLevelParts.Peek().transform.position.x > _partsSpacing)
            {
                GameObject part = _instantinatedLevelParts.Dequeue();
                part.SetActive(false);
                _levelParts.Add(part);
            }
        }
       
        private void GenerateRandomPart()
        {
            int partIndex = 0;
            partIndex = Random.Range(0, _levelParts.Count);

            GameObject part;
            if (_levelParts[partIndex].scene.name == null)
            {
                part = Instantiate(_levelParts[partIndex].gameObject,
                    new Vector3(_lastPartPosition.x + _partsSpacing,0, 0),
                    Quaternion.identity);
                _levelParts[partIndex] = part;
            }
            else
            {
                part = _levelParts[partIndex];
                foreach (var obstacle in part.GetComponent<LevelPart>().Obstacles)
                {
                    obstacle.SetActive(true);
                }
                part.SetActive(true);

                part.transform.position = new Vector3(_lastPartPosition.x + _partsSpacing,0, 0);
            }
           
            _levelParts.Remove(part);
            _instantinatedLevelParts.Enqueue(part);
           
            List<GameObject> obstacles = part.GetComponent<LevelPart>().Obstacles;
            int removedObstacleCount = Random.Range(0,obstacles.Count);
            _lastPartPosition = part.transform.position;
           
            for (int i = 0; i < removedObstacleCount; i++)
            {
                int obstacleIndex = i;
                while (true)
                {
                    obstacleIndex = Random.Range(0, obstacles.Count);
                    if(obstacles[obstacleIndex].activeSelf)
                        break;
                }
                obstacles[obstacleIndex].SetActive(false);
            }
        }
    }
}
