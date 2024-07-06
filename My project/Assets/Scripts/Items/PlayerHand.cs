using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHand : MonoBehaviour
{
    private Vector3 _mousePosition;

    public bool _rotationIsChanged = false;

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;

        if (_rotationIsChanged == false)
        {
            transform.right = (_mousePosition - transform.position) * -1f;

            if (transform.rotation.z > 0.7f || transform.rotation.z < -0.7f)
            {
                Debug.Log(transform.rotation.z);
                transform.localScale = new Vector3(-transform.localScale.x, -transform.localScale.y, -transform.localScale.z);
                _rotationIsChanged = true;
            } 
        }

        else if (_rotationIsChanged == true)
        {
            transform.right = (_mousePosition - transform.position);

            if (transform.rotation.z > -0.7f || transform.rotation.z < 0.7f)
            {
                Debug.Log(transform.rotation.z);
                transform.localScale = new Vector3(-transform.localScale.x, -transform.localScale.y, -transform.localScale.z);
                _rotationIsChanged = false;
            }  
        }

        

    }
}
