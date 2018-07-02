using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_360_Photo : MonoBehaviour {

    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";

    IEnumerator Start()
    {
        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            // assign texture
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = www.texture;
        }
    }
}
