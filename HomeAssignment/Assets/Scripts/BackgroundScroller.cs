using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //the speed of the scrolling
    [SerializeField] float BackgroundScrollSpeed;
    //The material from the texture
    Material material;
    //the movement
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        //get material of the background from the renderer component
        material = GetComponent<Renderer>().material;
        //will scroll in the y-axis at the speed given
        offSet = new Vector2(0f, BackgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //move the material textureOffSet by the movement offset every frame
        material.mainTextureOffset += offSet * Time.deltaTime;
    }
}
