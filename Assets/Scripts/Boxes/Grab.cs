using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private InputReaderDrone inputReader;
    [SerializeField] private LayerMask grabLayer;
    
    private bool canGrab = false;
    private HingeJoint _hingeJoint;
    private Rigidbody _box;

    void Start()
    {
        _hingeJoint = this.GetComponent<HingeJoint>();
        inputReader.IsGrabbingEvent += Grabbing;
    }
    
    private void Grabbing(bool obj)
    {
        
        if (obj && canGrab && _hingeJoint != null)
        {
            _hingeJoint.connectedBody = _box;
        }
        else
        {
            _hingeJoint.connectedBody = null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (CompareLayers.CompareLayerAndMask(other.gameObject.layer, grabLayer))
        {
            _box = other.GetComponent<BaseGrabable>().GetRigidbody();
            canGrab = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CompareLayers.CompareLayerAndMask(other.gameObject.layer, grabLayer))
        {
            canGrab = false; 
        }
    }
}
