using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTest : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject player;
    public float time;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.SetPosition(0,player.transform.position);
            lineRenderer.SetPosition(1,Vector3.Lerp(player.transform.position, Vector3.zero, time));
        }
    }
}
