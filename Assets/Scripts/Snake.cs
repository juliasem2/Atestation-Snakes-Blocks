using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public string Level;
    private void Update()
    {
        MoveTail();
    }

    public List<Transform> _tails;
    [SerializeField] private float _dictance;


    private void MoveTail()
    {
        float _sqrtDistance = Mathf.Sqrt(_dictance);
        Vector3 _previousPosition = transform.position;


        if (_tails != null)
        {
            foreach (var t in _tails)
            {
            
                if ((t.position - _previousPosition).sqrMagnitude > _sqrtDistance)
                {
                    Vector3 _currentPosition = t.position;
                    t.position = _previousPosition;
                    _previousPosition = _currentPosition;
                }
                else
                {
                    break;
                }
            }
        }
        
    }

}
