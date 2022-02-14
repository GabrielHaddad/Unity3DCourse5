using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] [Range(0.1f, 10f)] float damageDuration = 0.3f;

    void Start()
    {
        damageCanvas.enabled = false;
    }

    public void ShowDamageCanvas()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(damageDuration);
        damageCanvas.enabled = false;
    }
}
