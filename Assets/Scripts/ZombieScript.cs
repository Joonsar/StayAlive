using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    public enum ZombieType
    {
        shuffle,
        dizzy,
        alert
    }

    public ZombieType zombieStyle;
    public float yAdjustment = 0.0f;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(((int)zombieStyle + 1), 1);

        if (zombieStyle == ZombieType.shuffle)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + yAdjustment, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
