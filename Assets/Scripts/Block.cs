using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public UnityEvent<GameObject> onDestroy;
    public void DestroyBlock()
    {
        onDestroy.Invoke(gameObject);
    }
}
