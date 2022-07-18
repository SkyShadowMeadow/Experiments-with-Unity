using System.Collections;
using UnityEngine;

namespace Checks
{
    public class CubePower : MonoBehaviour
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private int _numberToPower = 5;
        [SerializeField] private float _distance = 0.5f;
        [SerializeField] private float _timeToMoveToTheFinalPoint = 1f;

        private int _currentRow = 1;
        private int _currentColum = 1;
        private int _created = 0;


        void Start()
        {
            CreateCubes();
        }

        private void CreateCubes()
        {
            Vector3 position = new Vector3(0, 0, 0);
            StartCoroutine(CreateLine(position));
        }

        private IEnumerator CreateLine(Vector3 position)
        {
            if (_created >= Mathf.Pow(_numberToPower, 3))
            {
                yield break;
            }

            Vector3 positionInRow = position;
            
            for (int i = 0; i < _numberToPower; i++)
            {
                //Instantiate(_unitPrefab, positionInRow, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(SmoothLerp(positionInRow));
                _created++;
                positionInRow = new Vector3(positionInRow.x + 1 + _distance, positionInRow.y, positionInRow.z);
            }

            if (_currentRow < _numberToPower)
            {
                positionInRow = new Vector3(0, positionInRow.y, positionInRow.z + 1 + _distance);
                _currentRow++;
                StartCoroutine(CreateLine(positionInRow));
            }

            else
            {
                if (_currentColum >= _numberToPower)
                    yield break;
                else if(_currentColum < _numberToPower)
                {
                    _currentRow = 1;
                    positionInRow = new Vector3(0, positionInRow.y + 1 + _distance, 0);
                    _currentColum++;
                    StartCoroutine(CreateLine(positionInRow));
                }
            }
        }
        
        private IEnumerator SmoothLerp (Vector3 finalPosition)
        {
            GameObject unit = Instantiate(_unitPrefab, _startPosition.position, Quaternion.identity);
            Vector3 startingPos = _startPosition.position;
            Vector3 finalPos = finalPosition;
            
            float elapsedTime = 0;
         
            while (elapsedTime < _timeToMoveToTheFinalPoint)
            {
                unit.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / _timeToMoveToTheFinalPoint));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
