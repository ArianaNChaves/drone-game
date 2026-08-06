using System;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoBox : BaseSupply
{
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override Rigidbody GetRigidbody()
    {
        Debug.Log(_rigidbody.gameObject.name);
        
        return base.GetRigidbody();
        
    }
}
