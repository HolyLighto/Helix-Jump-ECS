using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSystem : IEcsRunSystem

{
    private SceneObjects _sceneObjects;
    private Camera _camera;
    private Vector3 _targetPostiton;
    private float _maxY = float.MaxValue;
    private float _cameraOffsetY = 2;

    public void Run()
    {
        if ((_sceneObjects.Ball.transform.position.y < _maxY) && (_sceneObjects.Ball.transform.position.y - _maxY < 0.15))  _maxY = _sceneObjects.Ball.transform.position.y;
        _targetPostiton = new Vector3(_camera.transform.position.x, Mathf.Clamp(_sceneObjects.Ball.transform.position.y, float.MinValue, _maxY) + _cameraOffsetY, _camera.transform.position.z) ;
        _camera.transform.position = _targetPostiton;
    }
}
