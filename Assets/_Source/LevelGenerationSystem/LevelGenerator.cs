using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace LevelGenerationSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        private const string LEVEL_COUNT_KEY = "Level";
        
        [SerializeField] private List<GameObject> _levelParts;
        [SerializeField] private Transform _endPart;
        [SerializeField] private float _partsSpacing;
        [SerializeField] private int _generatedPartsCount;
        [SerializeField] private float _minObstaclePercentGlobally;
        [SerializeField] private int _minLevelPartsCountGlobally;

        private Queue<GameObject> _instantinatedLevelParts;
        private Transform _cameraTransform;
        private Vector3 _lastPartPosition;
        private int _partsCount;
        private int _maxPartsCount;
        private float _minObstacleCountPercent;
        private float _maxObstacleCountPercent;
        
        private void Awake()
        {
            _instantinatedLevelParts = new Queue<GameObject>();
            _cameraTransform = Camera.main.transform;
            _lastPartPosition = Vector3.zero;
            int level = PlayerPrefs.GetInt(LEVEL_COUNT_KEY, 1);
            
            _maxPartsCount = (int)(_minLevelPartsCountGlobally + level*1.5f);
            
            _minObstacleCountPercent = _minObstaclePercentGlobally + level*0.1f;
            _maxObstacleCountPercent = _minObstacleCountPercent + level*0.1f*1.5f;
            _minObstacleCountPercent = _minObstacleCountPercent > 0.8f ? 1f : _minObstacleCountPercent;
            _maxObstacleCountPercent = _maxObstacleCountPercent > 1f ? 1f : _maxObstacleCountPercent;
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
           
            if (_cameraTransform.position.x - _instantinatedLevelParts.Peek().transform.position.x > _partsSpacing )
            {
                GameObject part = _instantinatedLevelParts.Dequeue();
                part.SetActive(false);
                _levelParts.Add(part);
            }
        }
        
        private void GenerateRandomPart()
        {
            if (_partsCount == _maxPartsCount)
            {
                _endPart.position = new Vector3(_lastPartPosition.x + _partsSpacing, 0, 0);
                _partsCount++;
                return;
            }
            else if (_partsCount > _maxPartsCount)
            {
                return;
            }
            _partsCount++;
            
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
            int removedObstacleCount = Random.Range((int)Mathf.Lerp(0,obstacles.Count,1-_maxObstacleCountPercent),
                                                    (int)Mathf.Lerp(0,obstacles.Count,1-_minObstacleCountPercent));
            _lastPartPosition = part.transform.position;
           
            for (int i = 0; i < removedObstacleCount; i++)
            {
                int obstacleIndex;
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
