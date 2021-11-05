using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifPlayer : MonoBehaviour
{
    [SerializeField] private Animator gif;

    public void PlayGIF()
    {
        gif.gameObject.SetActive(true);
        Invoke("StopGIF", 8f);
    }

    /*private void Update()
    {
        if (gif.GetCurrentAnimatorStateInfo(0).IsName("TateTsukiGif") && gif.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gif.gameObject.SetActive(false);
            GifCompleted();
        }
    }*/

    public void StopGIF()
    {
        gif.gameObject.SetActive(false);
    }
}
