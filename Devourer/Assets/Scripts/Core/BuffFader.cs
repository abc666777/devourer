using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffFader : MonoBehaviour
{
    private Image image;
    private GameObject ob;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 5f);
        image = GetComponent<Image>();
        StartCoroutine(FadeTo(5f));
    }

    public static Color SetAlpha(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }
    IEnumerator FadeTo(float aTime)
    {
        float alpha = image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0f, t));
            image.color = newColor;
            yield return null;
        }
    }

    public void OnDestroy()
    {
        GameObject ob = UIManager.instance.CurrentlyDisplayBuffIcons.Find(x => x.name == this.name);
        if (ob != null)
        {
            UIManager.instance.CurrentlyDisplayBuffIcons.Remove(ob);
            Destroy(ob);
        }
    }
}
