using UnityEngine;
using TMPro;

public class CountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private ClickCounet _clickCounter;

    private void Awake() => _clickCounter = GetComponent<ClickCounet>();

    private void Update() => UpdateCounterText();

    private void UpdateCounterText() => _counterText.text = $"Count: {_clickCounter.MaxCount}";
}
