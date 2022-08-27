using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FiturShare : MonoBehaviour
{
    private string ShareMessage;
    public void clickShare()
    {
        ShareMessage = "EZ banget Boss";
        StartCoroutine(TakeScreenshoots());
    }

    IEnumerator TakeScreenshoots()
    {
        yield return new WaitForEndOfFrame();

        Texture2D t2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        t2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        t2D.Apply();

        string path = Path.Combine(Application.temporaryCachePath, "sharedImaged.png");
        File.WriteAllBytes(path, t2D.EncodeToPNG());
        Destroy(t2D);

        new NativeShare  ()
            .AddFile(path)
        .SetSubject("this is my Score")
        .SetText("Share your Score with your friend")
        .Share();

    }
}
