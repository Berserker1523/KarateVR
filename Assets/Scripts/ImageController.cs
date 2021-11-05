using System.Collections;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    public void ShowImage(string name, string delay)
    {
        int delayInt = int.Parse(delay);
        Transform child = transform.Find(name);
        if(child != null)
        {
            StartCoroutine(ActiveImage(child.gameObject, delayInt));
        }
    }

    private IEnumerator ActiveImage(GameObject image, int delay)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(delay);
        image.SetActive(false);
    }
}
