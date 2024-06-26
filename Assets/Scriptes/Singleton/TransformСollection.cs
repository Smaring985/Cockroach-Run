using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCollection : MonoBehaviour
{
   public static TransformCollection instance;
   public Transform _playerBody;

    void Start()
    {
        instance = this;
    }


}
