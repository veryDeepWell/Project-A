using System;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    public FuseSocket fuseSocket;

    public bool IsBroken = false;
    private bool _isDragged = false;
    private bool _isConnected = false;
    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        if (_isDragged == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 converted = Camera.main.ScreenToWorldPoint(mousePos);
            converted.z = 0;

            SetPosition(converted);

            //Vector3 endWireDifference = converted - _endWire.position;
            
            //if (endWireDifference.magnitude < 0.5f)
            //{
            //    transform.position = _endWire.position;
            //    _isDragged = false;
            //    _isConnected = true;
            //    SendThatIsConnected();
                
            //    SetPosition(_endWire.position);
            //}
        }
    }

    private void SendThatIsConnected()
    {
        WireBox wireBox = transform.root.gameObject.GetComponentInChildren<WireBox>();
        wireBox.connectedWires += 1;
        wireBox.WinCondition();
    }

    void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void ResetPosition()
    {
        _isConnected = false;
        _isDragged = false;
        SetPosition(_originalPosition);
    }

    private void OnMouseDown()
    {
        if (_isConnected != true)
        {
            _isDragged = true;
        }
    }
    
    private void OnMouseUp()
    {
        if (_isConnected != true)
        {
            _isDragged = false;
            ResetPosition();
        }
    }

    public bool IsConnected
    {
        get => _isConnected;
        set => _isConnected = value;
    }
}
