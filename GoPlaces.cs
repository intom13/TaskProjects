using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocateToPoint : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _numberInArray;
    [SerializeField] private Transform _allPlacespoint;
    [SerializeField] private Transform[] _arrayPlaces;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _allPlacespoint.childCount; i++)
            _arrayPlaces[i] = _allPlacespoint.GetChild(i);
    }

    private void Update()
    {
        var pointByNumberInArray = _arrayPlaces[_numberInArray];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
            Relocate();
    }

    private Vector3 Relocate()
    {
        _numberInArray++;

        if (_numberInArray == _arrayPlaces.Length)
            _numberInArray = 0;

        var thisPointVector = _arrayPlaces[_numberInArray].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}