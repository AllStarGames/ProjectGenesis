using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public enum DayState
    {
        Dawn,
        Day,
        Dusk,
        Night
    }
    public enum TemperateZone
    {
        Desert,         // high: 60.0f    | low:40.0f
        Plains,          // high: 30.0f     | low: -30.0f
        Rainforest, // high: 40.0f    | low: 1.0f
        Tropical,      // high: 30.0f    | low: 20.0f
        Tundra          // high: -30.0f  | low: -60.0f
    }

    [System.Serializable]
    public struct Fog
    {
        public float maxThickness;
        public float minThickness;
        public Gradient colour;

        private AnimationCurve cycle;
        private float thickness;

        public AnimationCurve Cycle()
        {
            return cycle;
        }
        public float Thickness()
        {
            return thickness;
        }
        public float MaxThickness()
        {
            return maxThickness;
        }
        public float MinThickness()
        {
            return minThickness;
        }
        public Gradient Colour()
        {
            return colour;
        }

        public void Create()
        {
            cycle = new AnimationCurve();
            thickness = minThickness;
        }
        public void SetMaxThickness(float value)
        {
            maxThickness = value;
        }
        public void SetMinThickness(float value)
        {
            minThickness = value;
        }
        public void SetThickness(float value)
        {
            thickness = value;
        }
        public void Thicken()
        {
            thickness = Mathf.Lerp(thickness, maxThickness, 0.5f * Time.deltaTime);
        }
        public void Thin()
        {
            thickness = Mathf.Lerp(thickness, minThickness, 0.5f * Time.deltaTime);
        }
    }
    [System.Serializable]
    public struct GameTime
    {
        public float cycleInSeconds;
        public float starting;

        private DayState ofDay;
        private float current;

        public DayState OfDay()
        {
            return ofDay;
        }
        public float Current()
        {
            return current;
        }
        public float CycleInSeconds()
        {
            return cycleInSeconds;
        }
        public float Starting()
        {
            return starting;
        }

        public void Display()
        {
            int hour = Mathf.FloorToInt(current / 60.0f);
            int minute = Mathf.FloorToInt(current - hour * 60.0f);
            string time = string.Format("{0:0}:{1:00}", hour, minute);
            print("Time: " + time);
        }
        public void SetCurrent(float time)
        {
            current = time;
        }
        public void SetSecondsInCycle(float seconds)
        {
            cycleInSeconds = seconds;
        }
        public void SetStarting(float time)
        {
            starting = time;
        }
        public void TimeOfDay(DayState state)
        {
            ofDay = state;
        }
        public void UpdateTimeOfDay()
        {
            if (current >= 240 && current < 720)
            {
                //Morning
                ofDay = DayState.Dawn;
            }
            else if (current >= 720 && current < 960)
            {
                //Daytime
                ofDay = DayState.Day;
            }
            else if (current >= 960 && current < 1200)
            {
                //Evening
                ofDay = DayState.Dusk;
            }
            else
            {
                //Nighttime
                ofDay = DayState.Night;
            }
        }
    }
    [System.Serializable]
    public struct Moon
    {
        public Color colour;
        public float intensity;
        public Light prefab;

        private Light moon;

        public Color Colour()
        {
            return colour;
        }
        public float Intensity()
        {
            return intensity;
        }
        public Light Get()
        {
            return moon;
        }
        public Light Prefab()
        {
            return prefab;
        }

        public void Create()
        {
            moon = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        public void Set(Light light)
        {
            moon = light;
        }
        public void SetIntensity(float value)
        {
            intensity = value;
        }
    }
    [System.Serializable]
    public struct Precipitation
    {
        public float cycle;
        public ParticleSystem prefab;

        private float currentChance;
        private float dailyChance;
        private float maxChance;
        private ParticleSystem emitter;

        public float CurrentChance()
        {
            return currentChance;
        }
        public float Cycle()
        {
            return cycle;
        }
        public float DailyChance()
        {
            return dailyChance;
        }
        public float MaxChance()
        {
            return maxChance;
        }
        public ParticleSystem Emitter()
        {
            return emitter;
        }
        public ParticleSystem Prefab()
        {
            return prefab;
        }

        public void Create()
        {
            emitter = Instantiate(prefab, new Vector3(0.0f, 20.0f, 0.0f), Quaternion.identity);
        }
        public void GetForNewTemperate(TemperateZone zone)
        {
            switch (zone)
            {
                case TemperateZone.Desert:
                    maxChance = 5.0f;
                    break;
                case TemperateZone.Plains:
                    maxChance = 70.0f;
                    break;
                case TemperateZone.Rainforest:
                    maxChance = 100.0f;
                    break;
                case TemperateZone.Tropical:
                    maxChance = 85.0f;
                    break;
                case TemperateZone.Tundra:
                    maxChance = 70.0f;
                    break;
            }

            GetNewDaily();
        }
        public void GetNewDaily()
        {
            dailyChance = Random.Range(0.0f, maxChance);
        }
        public void SetChance(float value)
        {
            currentChance = value;
        }
        public void SetCycle(float value)
        {
            cycle = value;
        }
        public void SetEmitter(ParticleSystem particleSystem)
        {
            emitter = particleSystem;
        }
    }
    [System.Serializable]
    public struct Prefabs
    {
        public Transform stars;
        public WindZone windZone;
    }
    [System.Serializable]
    public struct Sun
    {
        public float highestIntensity;
        public float lowestIntensity;
        public Gradient colour;
        public Light prefab;

        private AnimationCurve intensity;
        private Light sun;

        public AnimationCurve Intensity()
        {
            return intensity;
        }
        public float HighestIntensity()
        {
            return highestIntensity;
        }
        public float LowestIntensity()
        {
            return lowestIntensity;
        }
        public Gradient Colour()
        {
            return colour;
        }
        public Light Prefab()
        {
            return prefab;
        }
        public Light Get()
        {
            return sun;
        }

        public void Create()
        {
            sun = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        public void CreateIntensityCycle()
        {
            intensity = new AnimationCurve();
        }
        public void Set(Light light)
        {
            sun = light;
        }
        public void SetHighestIntensity(float value)
        {
            highestIntensity = value;
        }
        public void SetLowestIntensity(float value)
        {
            lowestIntensity = value;
        }
    }
    [System.Serializable]
    public struct Temperature
    {
        public bool imperialSystem;

        private AnimationCurve cycle;
        private float current;
        private float dailyLow;
        private float dailyHigh;
        private float lowestPossible;
        private float highestPossible;

        public AnimationCurve Cycle()
        {
            return cycle;
        }
        public float Convert(bool imperial, float temperature)
        {
            //Convert to fahrenheit
            if(imperial)
            {
                return (temperature * (9.0f / 5.0f)) + 32.0f;
            }
            //Convert celcius
            return (temperature - 32.0f) * (5.0f / 9.0f);
        }
        public float Current()
        {
            return current;
        }
        public float DailyHigh()
        {
            return dailyHigh;
        }
        public float DailyLow()
        {
            return dailyLow;
        }
        public float FreezingPoint()
        {
            if(imperialSystem)
            {
                return 32.0f;
            }
            return 0.0f;
        }
        public float HighestPossible()
        {
            return highestPossible;
        }
        public float LowestPossible()
        {
            return lowestPossible;
        }

        public void CreateCycle()
        {
            cycle = new AnimationCurve();
        }
        public void Display()
        {
            if(imperialSystem)
            {
                Debug.Log("Current Temperature: " + current.ToString() + " F\nDaily High: " + dailyHigh.ToString() + " F\nDaily Low: " + dailyLow.ToString() + "F");
            }
            else
            {
                Debug.Log("Current Temperature: " + current.ToString() + " C\nDaily High: " + dailyHigh.ToString() + " C\nDaily Low: " + dailyLow.ToString() + "C");
            }
        }
        public void GetForNewTemperate(TemperateZone zone)
        {
            switch (zone)
            {
                case TemperateZone.Desert:
                    if(imperialSystem)
                    {
                        highestPossible = Convert(imperialSystem, 60.0f);
                        lowestPossible = Convert(imperialSystem, 40.0f);
                    }
                    else
                    {
                        highestPossible = 60.0f;
                        lowestPossible = 40.0f;
                    }
                    break;
                case TemperateZone.Plains:
                    if (imperialSystem)
                    {
                        highestPossible = Convert(imperialSystem, 30.0f);
                        lowestPossible = Convert(imperialSystem, -30.0f);
                    }
                    else
                    {
                        highestPossible =  30.0f;
                        lowestPossible = -30.0f;
                    }
                    break;
                case TemperateZone.Rainforest:
                    if (imperialSystem)
                    {
                        highestPossible = Convert(imperialSystem, 40.0f);
                        lowestPossible = Convert(imperialSystem, 1.0f);
                    }
                    else
                    {
                        highestPossible =  40.0f;
                        lowestPossible = 1.0f;
                    }
                    break;
                case TemperateZone.Tropical:
                    if (imperialSystem)
                    {
                        highestPossible = Convert(imperialSystem, 30.0f);
                        lowestPossible = Convert(imperialSystem, 20.0f);
                    }
                    else
                    {
                        highestPossible =  30.0f;
                        lowestPossible = 20.0f;
                    }
                    break;
                case TemperateZone.Tundra:
                    if (imperialSystem)
                    {
                        highestPossible = Convert(imperialSystem, -30.0f);
                        lowestPossible = Convert(imperialSystem, -60.0f);
                    }
                    else
                    {
                        highestPossible =  -30.0f;
                        lowestPossible = -60.0f;
                    }
                    break;
            }

            GetNewDaily();
        }
        public void GetNewDaily()
        {
            //Get the new daily high and low temperatures
            dailyHigh = Random.Range(lowestPossible, highestPossible);
            dailyLow = Random.Range(lowestPossible, dailyHigh);
        }
        public void SetCurrent(float temperature)
        {
            current = temperature;
        }
        public void SetHighestPossible(float temperature)
        {
            highestPossible = temperature;
        }
        public void SetLowestPossible(float temperature)
        {
            lowestPossible = temperature;
        }
        public void ToggleImperialSystem()
        {
            imperialSystem = !imperialSystem;

            current = Convert(imperialSystem, current);
            dailyHigh = Convert(imperialSystem, dailyHigh);
            dailyLow = Convert(imperialSystem, dailyLow);
            highestPossible = Convert(imperialSystem, highestPossible);
            lowestPossible = Convert(imperialSystem, lowestPossible);
        }
    }
    

    public static EnvironmentManager instance { get; private set; }

    public TemperateZone zone;
    public Prefabs prefabs;
    public Fog fog;
    public GameTime time;
    public Moon moon;
    public Precipitation precipitation;
    public Sun sun;
    public Temperature temperature;
    
    private bool debugMode;
    private float debugSpeed;
    private float timer;
    private GameObject[] torches;
    private Material skyMaterial;
    private Transform stars;
    private Vector3 speed;
    private WindZone windZone;

    public static Fog GetFog()
    {
        return instance.fog;
    }
    public static GameTime GetTime()
    {
        return instance.time;
    }
    public static Moon GetMoon()
    {
        return instance.moon;
    }
    public static Precipitation GetPrecipitation()
    {
        return instance.precipitation;
    }
    public static Sun GetSun()
    {
        return instance.sun;
    }
    public static TemperateZone GetZone()
    {
        return instance.zone;
    }
    public static Temperature GetTemperature()
    {
        return instance.temperature;
    }

    public static ParticleSystem Stars()
    {
        return instance.stars.GetComponent<ParticleSystem>();
    }
    public void SetDebugFlag(bool value)
    {
        debugMode = value;
    }
            
	// Use this for initialization
	void Awake ()
    {
        //Check if an environment manager already exsists in the scene
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        //Set the debug flag
       // debugMode = GameManager.DebugMode();

        //Set the current time of day to the scene's starting time
        time.SetCurrent(time.Starting());

        //Check if a sun already exsists in the scene
        if(GameObject.FindGameObjectWithTag("Sun"))
        {
            Light existingSun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();

#if UNITY_EDITOR
            if (debugMode)
            {
                print("Found a sun in the scene: " + existingSun.name + "!");
            }
#endif
            sun.Set(existingSun);
        }
        else
        {
#if UNITY_EDITOR
            if (debugMode)
            {
                print("No sun found in scene!");
            }
#endif
            sun.Create();
        }
        //Set the intensity cycle
        sun.CreateIntensityCycle();
        Keyframe intensity = new Keyframe();
        intensity.time = 0.0f;
        intensity.value = sun.LowestIntensity();
        sun.Intensity().AddKey(intensity);
        intensity.time = 0.5f;
        intensity.value = sun.HighestIntensity();
        sun.Intensity().AddKey(intensity);
        intensity.time = 1.0f;
        intensity.value = sun.LowestIntensity();
        sun.Intensity().AddKey(intensity);

        //Check if a moon already exsists in the scene
        if(GameObject.FindGameObjectWithTag("Moon"))
        {
            Light existingMoon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Light>();

#if UNITY_EDITOR
            if (debugMode)
            {
                print("Found a moon in the scene: " + existingMoon.name + "!");
            }
#endif
            moon.Set(existingMoon);
        }
        else
        {
#if UNITY_EDITOR
            if (debugMode)
            {
                print("No moon found in scene!");
            }
#endif
            moon.Create();
        }
        //Set the intensity
        moon.Get().intensity = moon.Intensity();
        //Set the moon rotation opposite to the sun
        moon.Get().transform.eulerAngles = new Vector3(-sun.Get().transform.eulerAngles.x, moon.Get().transform.eulerAngles.y, moon.Get().transform.eulerAngles.z);

        //Check if a precipitation emitter already exsists in the scene
        if(GameObject.FindGameObjectWithTag("Precipitation"))
        {
            ParticleSystem existingEmitter = GameObject.FindGameObjectWithTag("Precipitation").GetComponent<ParticleSystem>();

#if UNITY_EDITOR
            if (debugMode)
            {
                print("Found a precipitation emitter in the scene: " + existingEmitter.name + "!");
            }
#endif
            precipitation.SetEmitter(existingEmitter);
        }
        else
        {
#if UNITY_EDITOR
            if (debugMode)
            {
                print("No precipitation emitter found in scene!");
            }
#endif
            precipitation.Create();
        }
        //Get the highest precipitation chance for this region
        precipitation.GetForNewTemperate(zone);
        precipitation.SetChance(Random.Range(0.0f, 100.0f));
        //Set the timer for precipitation
        timer = precipitation.Cycle();

        //Check if the stars already exist in the scene
        if(GameObject.FindGameObjectWithTag("Stars"))
        {
            Transform existingStars = GameObject.FindGameObjectWithTag("Stars").GetComponent<Transform>();

#if UNITY_EDITOR
            if (debugMode)
            {
                print("Found stars in the scene: " + existingStars.name + "!");
            }
#endif
            stars = existingStars;
        }
        else
        {
#if UNITY_EDITOR
            if (debugMode)
            {
                print("No stars found in the scene!");
            }
#endif
            stars = Instantiate(prefabs.stars, Vector3.zero, Quaternion.identity);
        }
        //Check if a wind zone already exists in the scene
        WindZone existingWindZone = GameObject.FindObjectOfType<WindZone>();
        if(existingWindZone)
        {
#if UNITY_EDITOR
            if(debugMode)
            {
                print("Found a wind zone in the scene: " + existingWindZone.name + "!");
            }
#endif
            windZone = existingWindZone;
        }
        else
        {
#if UNITY_EDITOR
            if (debugMode)
            {
                print("No wind zone found in the scene!");
            }
#endif
            //windZone = Instantiate(prefabs.windZone, Vector3.zero, Quaternion.identity);
        }

        //Get the highest/lowest possible temperatures for this region
        temperature.GetForNewTemperate(zone);

        temperature.CreateCycle();
        Keyframe dailyMid = new Keyframe();
        dailyMid.time = 0.0f;
        dailyMid.value = temperature.DailyLow() + (Mathf.Abs(temperature.DailyHigh() - temperature.DailyLow()) * 0.25f);
        temperature.Cycle().AddKey(dailyMid);
        Keyframe dailyLow = new Keyframe();
        dailyLow.time = 0.125f;
        dailyLow.value = temperature.DailyLow();
        temperature.Cycle().AddKey(dailyLow);
        Keyframe dailyHigh = new Keyframe();
        dailyHigh.time = 0.625f;
        dailyHigh.value = temperature.DailyHigh();
        temperature.Cycle().AddKey(dailyHigh);
        dailyMid.value = temperature.DailyHigh() - (Mathf.Abs(temperature.DailyHigh() - temperature.DailyLow()) * 0.75f);
        dailyMid.time = 1.0f;
        temperature.Cycle().AddKey(dailyMid);

        fog.Create();
        Keyframe thickness = new Keyframe();
        thickness.time = 0.0f;
        thickness.value = 0.0f;
        fog.Cycle().AddKey(thickness);
        thickness.time = 0.5f;
        thickness.value = 1.0f;
        fog.Cycle().AddKey(thickness);
        thickness.time = 1.0f;
        thickness.value = 0.0f;
        fog.Cycle().AddKey(thickness);
    }
    void DayNightCycle()
    {
        //Increment the current time
        time.SetCurrent(time.Current() + Time.deltaTime * debugSpeed);
        if (time.Current() >= time.CycleInSeconds())
        {
            //Reset the clock to 00:00 (12 a.m.)
            time.SetCurrent(time.Current() - time.CycleInSeconds());
        }
        if (time.Current() >= 0.0f && time.Current() < 0.5f)
        {
            //It's a new day!!!
            NewDay();
        }
        time.UpdateTimeOfDay();
        ToggleLights();

        //The angular distance the sun rotates between 00:00 and 12:00 (90 degrees -> 270 degrees) divided by 12:00 -> 00:00 in seconds
        speed = new Vector3(180.0f / (time.CycleInSeconds() * 0.5f), 0.0f, 0.0f) * Time.deltaTime;

#if UNITY_EDITOR
        speed *= debugSpeed;
#endif

        //Rotate the sun and moon
        sun.Get().transform.Rotate(speed);
        moon.Get().transform.Rotate(speed);

        float value = time.Current() / time.CycleInSeconds();

        sun.Get().intensity = sun.Intensity().Evaluate(value);
        sun.Get().color = sun.Colour().Evaluate(value);
        RenderSettings.ambientLight = sun.Get().color;

        moon.Get().color = moon.Colour();

        skyMaterial.SetFloat("AtmoshpereThickness", fog.Cycle().Evaluate(value));
    }
    void DebugLogic()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            temperature.ToggleImperialSystem();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (debugSpeed < 8)
            {
                Debug.Log("Increasing day/night cycle speed");
                debugSpeed *= 2.0f;
            }
            else
            {
                Debug.Log("Cannot increase day/night cycle speed more");
            }
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            if (debugSpeed > 1.0f)
            {
                Debug.Log("Decreasing day/night cycle speed");
                debugSpeed /= 2.0f;
            }
            else
            {
                Debug.Log("Cannot decrease day/night cycle speed more");
            }
        }

        print(time.OfDay().ToString());
    }
    void NewDay()
    {
        //Calaculate new daily temperatures
        temperature.GetNewDaily();

        //Calculate new daily precipitation chance
        precipitation.GetNewDaily();
    }
    void Start()
    {
        //Find and reference all the torches in the scene
        //torches = GameObject.FindGameObjectsWithTag("Torch");

        //Set variables
        skyMaterial = RenderSettings.skybox;
        debugSpeed = 1.0f;
        speed = Vector3.zero;
        
        time.UpdateTimeOfDay();
    }
    void ToggleLights()
    {
        //Toggle lights based on ToD and fog
        if(time.OfDay() == DayState.Dawn || fog.Thickness() < 0.03f)
        {
            //Check if there are any torches in the scene
            /*if (torches.Length > 0)
            {
                //Turn them off
                foreach (GameObject torch in torches)
                {
                    torch.GetComponent<Light>().enabled = false;
                }
            }

            //Check if there are any enemies in the scene
            if (EnemyManager.GetNumEnemies() > 0)
            {
                //Turn off the enemies' lights
                foreach (GameObject minion in EnemyManager.GetMinionPool())
                {
                    minion.GetComponentInChildren<Light>().enabled = false;
                }

                foreach (GameObject boss in EnemyManager.GetBossPool())
                {
                    boss.GetComponentInChildren<Light>().enabled = false;
                }
            }*/
        }
        else if(time.OfDay() == DayState.Dusk || fog.Thickness() >= 0.03f)
        {
            //Check if there are any torches in the scene
            /*if (torches.Length > 0)
            {
                //Turn them on
                foreach (GameObject torch in torches)
                {
                    torch.GetComponent<Light>().enabled = true;
                }
            }

            //Check if there are any enemies in the scene
            if (EnemyManager.GetNumEnemies() > 0)
            {
                //Turn off the enemies' lights
                foreach (GameObject minion in EnemyManager.GetMinionPool())
                {
                    minion.GetComponentInChildren<Light>().enabled = true;
                }

                foreach (GameObject boss in EnemyManager.GetBossPool())
                {
                    boss.GetComponentInChildren<Light>().enabled = true;
                }
            }*/
        }
    }
    // Update is called once per frame
    void Update ()
    {
        if(!GameManager.GamePaused())
        { 
#if UNITY_EDITOR
            if (debugMode)
            {
                DebugLogic();
            }
#endif
            timer -= debugSpeed * Time.deltaTime;
            if(timer <= 0.0)
            {
                //Re-roll for precipitation
                precipitation.SetChance(Random.Range(0.0f, 100.0f));

                //Reset timer
                timer = precipitation.Cycle();
            }

            //Check temperature for rain/snow
            ParticleSystem.MainModule module = precipitation.Emitter().main;
            if(temperature.Current() <= temperature.FreezingPoint())
            {
                //Snow
                module.startSizeX = 0.15f;
                module.startSizeY = 0.15f;
                module.startSizeZ = 0.15f;
            }
            else
            {
                //Rain
                module.startSizeX = 0.1f;
                module.startSizeY = 0.3f;
                module.startSizeZ = 0.1f;
            }

            ParticleSystem.EmissionModule emission = precipitation.Emitter().emission;
            if(precipitation.CurrentChance() > (100.0f - precipitation.DailyChance()))
            {
                //Make it rain!!!
                emission.enabled = true;
                fog.Thicken();
            }
            else
            {
                //Stop precipitating
                emission.enabled = false;
                fog.Thin();
            }
            RenderSettings.fogColor = fog.Colour().Evaluate(time.Current() / time.CycleInSeconds());
            RenderSettings.fogDensity = fog.Thickness();

            float temp = temperature.Cycle().Evaluate(time.Current() / time.CycleInSeconds());
            if(temperature.imperialSystem)
            {
                temp = temperature.Convert(true, temp);
            }
            temperature.SetCurrent(temp);

            DayNightCycle();
        }
    }
}