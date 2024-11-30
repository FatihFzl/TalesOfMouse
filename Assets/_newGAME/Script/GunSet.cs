using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSet : MonoBehaviour
{
    public GameObject sword;
    public GameObject bow;
    public GameObject arrow;
    
    public void SwordActive()
    {
        sword.SetActive(true);
    }
    public void ArrowActive()
    {
        arrow.SetActive(true);
    }
    public void BowActive()
    {
        bow.SetActive(true);
    }
    public void SwordDeActive()
    {
        sword.SetActive(false);
    }
    public void ArrowDeActive()
    {
        arrow.SetActive(false);
    }
    public void BowDeActive()
    {
        bow.SetActive(false);
    }

}
