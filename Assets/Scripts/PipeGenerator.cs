using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefas;

    private float countdown;
    public float timeDuration;
    public bool enableGenratePipe;

    private void Awake()
    {
        countdown = 1f;
        enableGenratePipe = false;
    }

    void Update()
    {
        if (enableGenratePipe == true)
        {
            countdown -= Time.deltaTime; //moi frame coundown -= 1 /fps
                                         //30 FPS: moi frame countdown giam di 1/30s, moi giay (30 frames) thi countdown giam di 1 dong 1
            if (countdown <= 0)
            {
                //Sinh ra ong
                Instantiate(pipePrefas, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
    }
}
