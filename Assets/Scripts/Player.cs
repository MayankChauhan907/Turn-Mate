using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 _startPos;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] float _speed = 10f;
    Quaternion _headinRotation;
    bool _isDirectionSet = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, _layerMask))
            {
                _startPos = hitInfo.point;
                _isDirectionSet = true;
                /*GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.position = hitInfo.point;
                Cube.transform.rotation = hitInfo.transform.rotation;*/
            }

        }
        if (_isDirectionSet)
        {
            rotateToDirection(_startPos, transform.position);
        }
    }

    void rotateToDirection(Vector3 oldPos, Vector3 newPos)
    {
        var Direction = oldPos - newPos;
        Quaternion LookAtRotation = Quaternion.LookRotation(Direction);
        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        //transform.rotation = LookAtRotationOnly_Y;
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, Time.deltaTime * _speed);
    }
}
