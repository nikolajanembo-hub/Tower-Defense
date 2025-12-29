using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpGui : MonoBehaviour
{
    [SerializeField] private Enemy owner;
    [SerializeField] private GameObject hpContainer;
    [SerializeField] private Image hpImage;
    [SerializeField] private TextMeshProUGUI hpText;

    private int startHp;
    private Transform mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main.transform;
        startHp = owner.Health;
        OnHit();
        owner.OnHit += OnHit;
    }

    private void Update()
    {
        transform.forward = transform.position - mainCamera.position;
    }

    private void OnHit()
    {
        bool shouldBeActive = owner.Health > 0 && owner.Health != startHp;
        if (hpContainer.activeInHierarchy != shouldBeActive)
        {
            hpContainer.SetActive(shouldBeActive);
        }
        hpText.SetText(owner.Health.ToString());
        Vector3 current = hpImage.rectTransform.localScale;
        current.x = (float)owner.Health / startHp;
        hpImage.rectTransform.localScale = current;
    }
}
