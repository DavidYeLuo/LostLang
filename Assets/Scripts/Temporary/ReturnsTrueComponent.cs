using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnsTrueComponent : MonoBehaviour
{
    private ReturnsTrue returnsTrue;
    // Start is called before the first frame update
    void Start()
    {
        returnsTrue = new ReturnsTrue();
    }
    public bool ReturnTrue()
    {
        return returnsTrue.ReturnTrue();
    }
}
