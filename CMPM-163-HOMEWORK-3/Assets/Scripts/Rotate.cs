using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // this rotates each cube.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);


        // --------------------------------------------------------
        // ------- animate the cube size based on spectrum data.

        // consolidate spectral data to 8 partitions (1 partition for each rotating cube)
        int numPartitions = 8;
        float[] aveMag = new float[numPartitions];
        float partitionIndx = 0;
        int numDisplayedBins = 512 / 2; //NOTE: we only display half the spectral data because the max displayable frequency is Nyquist (at half the num of bins)

        for (int i = 0; i < numDisplayedBins; i++)
        {
            if (i < numDisplayedBins * (partitionIndx + 1) / numPartitions)
            {
                aveMag[(int)partitionIndx] += AudioPeer.spectrumData[i] / (512 / numPartitions);
            }
            else
            {
                partitionIndx++;
                i--;
            }
        }

        // scale and bound the average magnitude.
        for (int i = 0; i < numPartitions; i++)
        {
            aveMag[i] = (float)0.5 + aveMag[i] * 100;
            if (aveMag[i] > 100)
            {
                aveMag[i] = 100;
            }
        }


        //transform.localScale = new Vector3(aveMag[0], aveMag[1], aveMag[1]);
        int RandomX = Random.Range(0, 2);
        int RandomY = Random.Range(0, 2);
        int RandomZ = Random.Range(0, 2);
        /*
                Renderer temp = GetComponent<Renderer>();
                if (RandomX == 0)
                {
                    GetComponent<Renderer>().material.color = Color.yellow;

                }
                else
                    GetComponent<Material>().color = temp.color;
                    */


        // Map the magnitude to the cubes based on the cube name.


        if (RandomX == 0)
        {
            RandomX = 1;
            RandomY = 0;
            RandomZ = 0;

        }

        if (gameObject.tag == "BigPulse")
        {
            transform.localScale = new Vector3(aveMag[RandomX], aveMag[RandomY], aveMag[RandomZ]);
        }
        else if (gameObject.tag == "SmallPulse")
        {
            transform.localScale = new Vector3(aveMag[RandomX], aveMag[RandomY], aveMag[RandomZ]);
        }
        else
            transform.localScale = new Vector3(aveMag[0], aveMag[0], aveMag[0]);



    }


}
