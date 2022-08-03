using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManagers : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private int _blockCount;
    [SerializeField] private float _radius;

    private void Start()
    {
        for (int i = 0; i < _blockCount; i++)
        {
            SpawnBlock();
        }

    }
    public void SpawnBlock()
    {
        GameObject block = (Instantiate(_blockPrefab, Random.onUnitSphere * _radius, Quaternion.identity));
        block.transform.LookAt(_planet.transform.position);
        
        block.GetComponent<Block>().onDestroy.AddListener(DestroyBlock);
    }
    public void DestroyBlock(GameObject block)
    {
        SpawnBlock();
        Destroy(block.gameObject);
        
    }
    
}
