using System.Collections;
using UnityEngine;
using System;

public class ClickCounter : MonoBehaviour, ICounterElement
{
    [SerializeField] private int _count = 0;

    private Coroutine _coroutine;
    private float _waitTimeInSecond = 0.5f;
    private bool _isCounting = true;

    public event Action CountChanged;

    public int Count => _count;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            ToggleCounting();
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _isCounting = false;
        }
        else
        {
            _coroutine = StartCoroutine(IncrementCount());
            _isCounting = true;
        }
    }

    public IEnumerator IncrementCount()
    {
        var waitForSecond = new WaitForSeconds(_waitTimeInSecond);

        while (enabled)
        {
            _count++;
            CountChanged?.Invoke();
            yield return waitForSecond;
        }
    }
}
