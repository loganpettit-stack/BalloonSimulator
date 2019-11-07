/*
* Jacob Potter
* 10/22/2019
* CS 4500 Balloon Simulation
* This class simulates a realistic wind force on a rigidbody
* It also provides a static interface to adjust wind strength, pulse, and turbulence.
*
*/

using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
    static float constantStrength;
    static float turbulence;
    static float pulseMagnitude;
    static float pulseFrequency;
    static float instantaneousStrength;
    Rigidbody2D balloon;
    Slider windSlider;
    Vector2 startingPosition;
    Rigidbody2D anchor;

    const float stringStrength = 2;

    //use a generated low-frequency noise to simulate random wind pulse
    float[] lowFrequencyNoise;

    void Start()
    {
        //JSONconfig config = GameObject.Find("ROOT/GAMEMANAGER").GetComponent<JSONconfig>();
        //float maxSpeed = config.config.maxWindSpeed;
        //float minSpeed = config.config.minWindSpeed;
        //anchor = GameObject.Find("ROOT/WEIGHT").GetComponent<Rigidbody2D>();

        pulseMagnitude = 8f;
        pulseFrequency = 0.5f;
        turbulence = 10;
        windSlider = GameObject.Find("ROOT/UI/CPANEL_RIGHT/CPANEL_BOTTOM/PANEL_WIND/SLIDER_CONTAINER/SLIDER_RADIUS").GetComponent<Slider>();
        windSlider.minValue = 0;
        windSlider.value = 0;


        windSlider.onValueChanged.AddListener(
             delegate { SetStrength(windSlider.value); }
             );


        balloon = GameObject.Find("ROOT/BALLOON").GetComponent<Rigidbody2D>();

        startingPosition = balloon.transform.position;

        lowFrequencyNoise = new float[1024];

        //start with white noise in [0,1]
        for (int i = 0; i < lowFrequencyNoise.Length; i++)
            lowFrequencyNoise[i] = Random.value;

        //perform gaussian smoothing (twice) as a simple low-pass filter
        GaussianSmooth(lowFrequencyNoise);
        GaussianSmooth(lowFrequencyNoise);
    }

    void Update()
    {
        constantStrength = windSlider.value;
    }

    void FixedUpdate()
    {
        //instantaneous turbulence is a random value in (-1,1) * turbulence strength 
        //we also multiply it by the amount of time that has passed for accuracy
        float instantaneousTurbulence = turbulence * 2 * (Random.value - 0.5f) * Time.deltaTime;

        //get the current pulse using time * frequency to obtain the index 
        instantaneousStrength =
        lowFrequencyNoise[(int)(pulseFrequency * Time.timeSinceLevelLoad) % lowFrequencyNoise.Length];

        //multiply by the pulse strength
        instantaneousStrength *= pulseMagnitude;

        //add turbulence 
        instantaneousStrength += instantaneousTurbulence;

        //add constant wind strength 
        instantaneousStrength *= constantStrength;

        //apply the force to the balloon
        balloon.AddForce(new Vector2(-1, 0.1f) * instantaneousStrength);

        //pull of the string gets stronger as the balloon gets further away
        balloon.AddForce((startingPosition -
                          new Vector2(balloon.transform.position.x, balloon.transform.position.y))
                          * stringStrength);
    }

    static void GaussianSmooth(float[] array)
    {
        float[] kernel = new float[17];

        //standard deviation
        const float a = 4.0f;

        //create a normal curve for our kernel distribution
        const float e = 2.71828182846f;
        for (int i = 0; i < kernel.Length; i++)
        {
            float x = i - (kernel.Length / 2);
            //formula for normal curve, sum of weights = 1
            kernel[i] =
    (1.0f / (a * Mathf.Sqrt(2 * Mathf.PI))) *
    Mathf.Pow(e, -((x * x) / (2 * a * a)));
        }

        //perform smoothing
        for (int i = 0; i < array.Length; i++)
        {
            int n = i - kernel.Length / 2;
            float avg = 0;
            int k = 0;
            //starting at i - kernelSize/2
            while (n < i + kernel.Length / 2)
            {
                if (n > 0 && n < array.Length)
                {
                    //get the average, weighted by the kernel
                    avg += array[n] * kernel[k];
                }
                k++;
                n++;
            }
            //the new value is the weighted averages of nearby values 
            array[i] = avg;
        }

    }

    public void SetStrength(float v)
    {
        constantStrength = v;
    }
}

