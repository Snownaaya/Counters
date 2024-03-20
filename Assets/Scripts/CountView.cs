using UnityEngine;
using TMPro;

public class CountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private ClickCounter _clickCounter;

    private void Awake() => _clickCounter = GetComponent<ClickCounter>();

    private void OnEnable() => _clickCounter.CountChanged += UpdateCounterText;

    private void OnDisable() => _clickCounter.CountChanged -= UpdateCounterText;

    private void UpdateCounterText() => _counterText.text = $"Count: {_clickCounter.Count}";
}
