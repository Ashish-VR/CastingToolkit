using System.Collections;
using UnityEngine;

public class DeactivateAfterSeconds : MonoBehaviour
{
    [SerializeField] float seconds;
    Coroutine off;

    private void OnEnable()
    {
        if (off != null)
        {
            StopCoroutine(off);
            off = null;
        }

        off = StartCoroutine(turnAfter());
    }

    IEnumerator turnAfter()
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
