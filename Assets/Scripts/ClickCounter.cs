using System.Collections;
using UnityEngine;
using System;

public class ClickCounter : MonoBehaviour, ICounterElement
{
    [SerializeField] private int _count = 0;

    private Coroutine _coroutine;
    private float _waitTimeInSecond = 0.5f;

    public event Action CountChanged;

    public int Count => _count;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            ToggleCounting();
    }

    private void ToggleCounting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(IncrementCount());
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
