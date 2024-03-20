using System.Collections;
using UnityEngine;

public class ClickCounet : MonoBehaviour, ICounterElement
{
    [SerializeField] private int _count = 0;

    private Coroutine _coroutine;
    private float _waitTimeInSecond = 0.5f;
    private bool _isCounting = true;

    public int MaxCount => _count;

    private void Awake() => StartCoroutine(IncrementCount());

    private void Update()
    {
        if (Input.GetMouseButton(0))
            _isCounting = !_isCounting;
    }

    public IEnumerator IncrementCount()
    {
        var waitForSecond = new WaitForSeconds(_waitTimeInSecond);

        while (enabled)
        {
            if (_isCounting)
                _count++;

            yield return waitForSecond;
        }
    }
}
