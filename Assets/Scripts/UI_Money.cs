using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Money : MonoBehaviour
{
    private RectTransform rectTr = null;
    private TextMeshProUGUI textMoney = null;

    private void Awake()
    {
        rectTr = GetComponent<RectTransform>();
        textMoney = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdatePosition( Vector3 _worldPos)
    {
        Vector3 w2s =
        Camera.main.WorldToScreenPoint(_worldPos);
        rectTr.position = w2s + new Vector3 (0f, 30f, 0f);
    }
    public void UpdateMoney(int _Money)
    {
        textMoney.text = _Money.ToString();
    }

}
