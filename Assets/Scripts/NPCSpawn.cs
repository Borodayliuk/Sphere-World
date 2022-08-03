using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _NPCPrefab;
    [SerializeField] private int _NPCCount;
    [SerializeField] private float _planetRadius = 26;
    private List<GameObject> _NPCs = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < _NPCCount; i++)
        {
            SpawnNPC();
        }
    }
    public void SpawnNPC()
    {
        GameObject NPC = (Instantiate(_NPCPrefab, Random.onUnitSphere * _planetRadius, Quaternion.identity));
        NPC.GetComponent<GravityBody>()._planet = _planet.GetComponent<GravityAttractor>();
        NPC.GetComponent<NPCControll>().restart.AddListener(Restart);
        NPC.GetComponent<AddBlock>().Add(Random.Range(0, 10));
        _NPCs.Add(NPC);
    }
    public void Restart(GameObject npc)
    {
        Destroy(npc);
        SpawnNPC();
    }
}
