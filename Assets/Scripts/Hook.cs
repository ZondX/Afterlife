using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _mousePosition;
    private Vector3 _currentPosition;
    private DistanceJoint2D _distanceJoint;
    private LineRenderer _lineRenderer;
    private bool _cheak;
    [SerializeField] private LayerMask _mask;
    void Start()
    {
        _camera = Camera.main;
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint.enabled = false;
        _lineRenderer.positionCount = 0;
        _cheak = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        MouseMove();
        RaycastHit2D rayHit = Physics2D.Raycast(_camera.transform.position, _mousePosition, Mathf.Infinity, _mask);
        if (Input.GetMouseButtonDown(0) && _cheak && rayHit)
        {
            _distanceJoint.enabled = true;
            _distanceJoint.distance = Vector2.Distance(transform.position, rayHit.point);
            _distanceJoint.connectedAnchor = rayHit.point;
            _lineRenderer.positionCount = 2;
            _currentPosition = rayHit.point;
            _cheak = false;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _distanceJoint.enabled = false;
            _cheak = true;
            _lineRenderer.positionCount = 0;
        }
        DrawLine();
    }
    private void DrawLine()
    {
        if(_lineRenderer.positionCount > 0)
        {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _currentPosition);
        }
    }
    private void MouseMove()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
