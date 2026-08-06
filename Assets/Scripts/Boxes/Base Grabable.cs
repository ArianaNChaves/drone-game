using System;
using UnityEngine;

public abstract class BaseGrabable : MonoBehaviour
{
    protected Rigidbody _rigidbody;


    public virtual Rigidbody GetRigidbody()
    {
        return this._rigidbody;
    }
}
