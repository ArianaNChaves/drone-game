using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private InputReaderDrone inputReader;
    [SerializeField] private GameObject magnetObject;
    [SerializeField] private LayerMask grabLayer;
    
    private bool _canGrab = false;
    private HingeJoint _hingeJoint;
    private Rigidbody _box;
    private LayerMask _magnetLayer;
    private LayerMask _playerLayer;
    
    
    void Start()
    {
        _hingeJoint = this.GetComponent<HingeJoint>();
        inputReader.IsGrabbingEvent += Grabbing;
        _magnetLayer = LayerMask.NameToLayer("Magnet");
        _playerLayer = LayerMask.NameToLayer("Player");
    }
    
    private void Grabbing()
    {

        if (!_canGrab)
        {
            return;
        }
        
        if (_hingeJoint.connectedBody != null)
        {
            Detach();
        } 
        else if (_hingeJoint.connectedBody == null)
        {
            Attach();
        }
    }

    private void Attach()
    {
        magnetObject.layer = _playerLayer;
        _hingeJoint.connectedBody = _box;
    }

    private void Detach()
    {
        magnetObject.layer = _magnetLayer;
        _hingeJoint.connectedBody = null;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (CompareLayers.CompareLayerAndMask(other.gameObject.layer, grabLayer))
        {
            _box = other.GetComponent<BaseGrabable>().GetRigidbody();
            _canGrab = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CompareLayers.CompareLayerAndMask(other.gameObject.layer, grabLayer))
        {
            Detach();
            _canGrab = false; 

        }
    }
}
