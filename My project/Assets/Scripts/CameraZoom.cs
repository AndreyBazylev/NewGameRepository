using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CinemachineFollowZoom _followZoom;
    [SerializeField] private float _sensitivity = 1f;

    private CinemachineComponentBase _componentBase;
    private float _cameraDistatance;

    void Update()
    {
        if (_componentBase == null)
        {
            _componentBase = _camera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _cameraDistatance = Input.GetAxis("Mouse ScrollWheel") * _sensitivity;

            if (_cameraDistatance != 0)
            {
                _camera.m_Lens.OrthographicSize -= _cameraDistatance;

                if (_camera.m_Lens.OrthographicSize < _followZoom.m_MinFOV)
                {
                    _camera.m_Lens.OrthographicSize = _followZoom.m_MinFOV;
                }

                if (_camera.m_Lens.OrthographicSize > _followZoom.m_MaxFOV)
                {
                    _camera.m_Lens.OrthographicSize = _followZoom.m_MaxFOV;
                }
            }   
        }
    }
}
