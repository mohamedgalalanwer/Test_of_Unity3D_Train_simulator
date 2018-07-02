using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavCanvasPhoto : MonoBehaviour {

    public GameObject photo360, mall, canvasSkip, player, searchcanvas, cam, navcanv,lights;

    Ray ray;
    RaycastHit hit;
    LayerMask inter;

    void OnMouseDown()
    {
        mall.SetActive(false);
        canvasSkip.SetActive(true);
        //canvasSkip.SetActive(true);
        player.SetActive(false);
        searchcanvas.SetActive(false);
        cam.SetActive(true);
        cam.transform.position = new Vector3(0, 0, 0);
        navcanv.SetActive(false);
        photo360.SetActive(true);
        lights.SetActive(false);
    }

    void Update()
    {
        //if (Input.touchCount > 0/* || Input.GetTouch(0).phase == TouchPhase.Began*/)
        //{
        //    ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        //    if (Physics.Raycast(ray, out hit, inter, 20))
        //    {
        //        Debug.Log("photo appeare");
        //    }
        //}

    }
}
