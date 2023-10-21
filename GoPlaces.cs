using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerialiseField] private float _speed;
    [SerializeField] private int _numberInArray;
    [SerializeField] private Transform _allPlacespoint;
    [SerializeField] private Transform[] _arrayPlaces;

    private void Start()
    { 
        _arrayPlaces = new Transform[_allPlacespoint.childCount];

        for (int abcd = 0; abcd < _allPlacespoint.childCount; abcd++)
            _arrayPlaces[abcd] = _allPlacespoint.GetChild(abcd).GetComponent<Transform>();
    }
    
    private void Update()
    {
        var PointByNumberInArray = _arrayPlaces[_numberInArray];
        transform.position = Vector3.MoveTowards(transform.position, PointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == PointByNumberInArray.position)
            NextPlaceTakerLogic();
    }

    private Vector3 NextPlaceTakerLogic()
    {
        _numberInArray++;

        if (_numberInArray == _arrayPlaces.Length)
            _numberInArray = 0;

        var ThisPointVector = _arrayPlaces[_numberInArray].transform.position;
        transform.forward = ThisPointVector - transform.position;

        return ThisPointVector;
    }
}