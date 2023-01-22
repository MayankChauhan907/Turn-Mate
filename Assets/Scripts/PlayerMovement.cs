using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Vector3 _startPos;
    NavMeshAgent _agent;
    bool _isDirectionSet;
    PhotonView _view;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_view.IsMine)
        {
            return;
        }

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
            _agent.SetDestination(_startPos);

        }


    }
}
