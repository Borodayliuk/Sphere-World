using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddBlock : MonoBehaviour
{
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _textScore;
    private List<GameObject> _blocks = new List<GameObject>();
    public float jumpForce = 220;
    public int score = 0;

    private void Update()
    {
        _textScore.GetComponent<TextMeshProUGUI>().text = "" + score;
    }

    // Update is called once per frame

    public void Add(int count)
    {
        for (int i = 0; i < count; i++)
        {
            score++;
            //GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
            GameObject block = Instantiate(_block);
            block.transform.rotation = transform.rotation;
            block.transform.parent = transform;
            block.transform.localPosition = Vector3.zero;
            if (_blocks.Count > 0)
            {
                block.transform.localPosition = _blocks[_blocks.Count - 1].transform.localPosition - (Vector3.up * 0.1f);

            }
            else
            {
                block.transform.localPosition -= Vector3.up * 1.1f;

            }
            GetComponent<CapsuleCollider>().center += new Vector3(0, -0.1f, 0);
            _blocks.Add(block);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            if (collision.gameObject.TryGetComponent(out Block block))
            {
                block.DestroyBlock();
                Add(1);
            }
            if (collision.gameObject.TryGetComponent(out AddBlock p))
            {
                if (score > p.score)
                {

                    Add(p.score);

                    if (p.TryGetComponent(out PlayerController player))
                    {
                        player.Restart();
                    }
                    else if (p.TryGetComponent(out NPCControll npc))
                    {
                        npc.Restart();
                    }
                }

            }
        }
    }
    public void Restart()
    {
        for (int i = 0; i < _blocks.Count; i++)
        {
            Destroy(_blocks[i].gameObject);
        }
        GetComponent<CapsuleCollider>().center = Vector3.zero;
        _blocks.Clear();
    }
}
