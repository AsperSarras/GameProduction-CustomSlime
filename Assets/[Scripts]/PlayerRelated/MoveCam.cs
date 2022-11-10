using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    //public Transform camPos;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = camPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = camPos.position;
    }
}
