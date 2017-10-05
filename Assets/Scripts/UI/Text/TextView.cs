using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextView : MonoBehaviour {

    /// <summary>
    /// Coroutine to fade in the given line of text onto the TextBox
    /// </summary>
    /// <param name="t">Length of fade in</param>
    /// <param name="i">Text to fade in</param>
    /// <returns></returns>
    public IEnumerator FadeInText(float t, Text i)
    {
        // Creates new color at maximum alpha
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        // While colour is less than white, increment color
        while (i.color.a < 1f)
        {
            if (i == null)
            {
                yield break;

            }
            else
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }

        }

    }

}
