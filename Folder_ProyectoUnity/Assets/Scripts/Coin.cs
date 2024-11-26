using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(90, 0, 0);

        transform.DOLocalRotate(new Vector3(90, 360, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GainCoin();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}