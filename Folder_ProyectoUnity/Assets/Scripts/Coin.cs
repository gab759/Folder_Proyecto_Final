using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    public float speed = 5f;
    private bool isMagnetActive = false; 
    private Transform magnetPivot;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(90, 0, 0);

        transform.DOLocalRotate(new Vector3(90, 360, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    private void OnEnable()
    {
        GameManager.Instance.OnMagnetActivate += HandleMagnetActivation;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMagnetActivate -= HandleMagnetActivation;
    }

    private void Update()
    {
        if (isMagnetActive && magnetPivot != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, magnetPivot.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
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
    private void HandleMagnetActivation(bool isActive)
    {
        isMagnetActive = isActive;
        if (isMagnetActive)
        {
            if (GameManager.Instance.MagnetPivot != null)
            {
                magnetPivot = GameManager.Instance.MagnetPivot; // Referencia del gameManager
            }
            else
            {
                Debug.LogWarning("No se encontró una referencia al imán en el GameManager.");
                isMagnetActive = false;
            }
        }
        else
        {
            magnetPivot = null; // Desactivar el imán
        }
    }
}