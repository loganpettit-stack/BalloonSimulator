/* SnapShotManager.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * This class simulates a realistic wind force on a rigidbody
 * and provides a static interface to adjust wind strength, pulse, and turbulence.
 * It also simulates the force of the string on the balloon
 */

using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
    public static float constantStrength;
    static float turbulence;
    static float pulseMagnitude;
    static float pulseFrequency;
    static float instantaneousStrength;
    const float maxStringLength = 5f;
    static Rigidbody2D balloon;
    static ConstantForce2D constForce;
    static Slider windSlider;
    static Vector2 startingPosition;
    static Rigidbody2D anchor;
    static Text windText;

    const float stringStrength = 8;

    //use a generated low-frequency noise to simulate random wind pulse
    float[] lowFrequencyNoise;
    float forceY;

    /// <summary>
    /// Setup, grab components
    /// </summary>
    void Start()
    {
        //JSONconfig config = GameObject.Find("ROOT/GAMEMANAGER").GetComponent<JSONconfig>();
        //float maxSpeed = config.config.maxWindSpeed;
        //float minSpeed = config.config.minWindSpeed;
        //anchor = GameObject.Find("ROOT/WEIGHT").GetComponent<Rigidbody2D>();

        pulseMagnitude = 8f;
        pulseFrequency = 0.5f;
        turbulence = 10;
        windSlider = GameObject.Find("ROOT/UI/CPANEL_RIGHT/CPANEL_BOTTOM_R/PANEL_WIND/SLIDER_CONTAINER/SLIDER_WIND").GetComponent<Slider>();
        windSlider.minValue = 0;
        windSlider.value = 0;

        windText = GameObject.Find("ROOT/UI/CPANEL_RIGHT/CPANEL_BOTTOM_R/PANEL_WIND/PANEL_SLIDER_VALUE_HOLDER/TEXT_SELECTED").GetComponent<Text>();

        GameObject.Find("ROOT/UI/CPANEL_RIGHT/CPANEL_BOTTOM_R/PANEL_WIND/SLIDER_CONTAINER/TEXT_SLIDER_MAX").GetComponent<Text>().text = "4 m/s";

        windSlider.onValueChanged.AddListener(
             delegate { SetStrength(windSlider.value); }
             );


        balloon = GameObject.Find("ROOT/BALLOON").GetComponent<Rigidbody2D>();

        if (balloon.transform.GetComponent<SpringJoint2D>())
        {
            balloon.transform.GetComponent<SpringJoint2D>().enabled = false;
        }

        anchor = GameObject.Find("ROOT/WEIGHT").GetComponent<Rigidbody2D>();
        rope_restrictballmovement rope = anchor.GetComponent<rope_restrictballmovement>();

        rope.bounds[0] *= 1.5f;
        rope.bounds[1] *= 1.5f;

        constForce = balloon.GetComponent<ConstantForce2D>();
        constForce.force *= (Vector2.up * 1.2f);
        forceY = constForce.force.y;

        startingPosition = balloon.transform.position;
        startingPosition = new Vector2(0, startingPosition.y);

        lowFrequencyNoise = new float[1024];

        //start with white noise in [0,1]
        for (int i = 0; i < lowFrequencyNoise.Length; i++)
            lowFrequencyNoise[i] = Random.value;

        //perform gaussian smoothing (twice) as a simple low-pass filter
        GaussianSmooth(lowFrequencyNoise);
        GaussianSmooth(lowFrequencyNoise);
    }

    /// <summary>
    /// Update UI regarding wind strength slider
    /// </summary>
    void Update()
    {

        string s = constantStrength.ToString();

        if (s.Length > 3)
            s = s.Substring(0, 3);

        s += " m/s";
        windText.text = s;
    }

    /// <summary>
    /// Perform wind simulation and calculations
    /// </summary>
    void FixedUpdate()
    {
        constantStrength = windSlider.value;

        balloon.angularVelocity = 0;

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

        //set the wind force 
        //constForce.force = new Vector2((startingPosition.x - balloon.transform.position.x) * stringStrength, constForce.force.y) + (new Vector2(-4, 0f) * instantaneousStrength);
        constForce.force = new Vector2(((balloon.transform.localScale.x - 0.8f > 0) ? (balloon.transform.localScale.x - 0.8f) : 0) * (startingPosition.x - balloon.transform.position.x) * stringStrength, constForce.force.y) + (new Vector2(-4, 0f) * instantaneousStrength);

        //distance from the anchor
        float magnitude = Vector2.Distance(anchor.transform.position, balloon.transform.position);

        //if the balloon gets too high, push it down 
        float yDown = 0;
        if (balloon.transform.position.y > maxStringLength && constForce.force.y >= 10)
            yDown = 1;

        //if the balloon is too far from the anchor, pull it back 
        if (magnitude > maxStringLength)
        {
            constForce.force += Mathf.Pow((magnitude - maxStringLength), 2) * -0.025f * new Vector2(1, yDown);
        }
        else
            constForce.force = new Vector2(constForce.force.x, forceY);

        //if its laying on the ground, but its inflated, push it up a bit.
        if (balloon.transform.position.y < 1 && balloon.transform.localScale.x > 0.5f)
        {
            balloon.transform.position += (Vector3.up * Time.deltaTime);
        }

        constForce.force = new Vector2(constForce.force.x, forceY * balloon.transform.localScale.x);

    }

    /// <summary>
    /// Performs gaussian smoothing on dataset
    /// </summary>
    /// <param name="array"></param>
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

    /// <summary>
    /// Sets constant straight of wind
    /// </summary>
    /// <param name="v"></param>
    public void SetStrength(float v)
    {
        constantStrength = v;
    }

    /// <summary>
    /// Calculates the force on the weight with the upwards helium force plus the amount of force exerted sideways.
    /// </summary>
    /// <returns></returns>
    public static float WeightForce()
    {
        float dist = Vector3.Distance(anchor.transform.position, balloon.transform.position);

        return (dist < maxStringLength * 0.9f) ? 0 : constForce.force.magnitude;
    }
}

