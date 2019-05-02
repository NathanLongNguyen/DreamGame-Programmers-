using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticle : MonoBehaviour
{
    public GameObject dustCloud;
    public void FootHit()
    {
        Instantiate(dustCloud, transform.position, transform.rotation);
    }
}
