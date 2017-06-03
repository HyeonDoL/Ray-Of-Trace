using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private int frameRange = 60;

    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    private int[] fpsBuffer;
    private int fpsBufferIndex;

    private void Update()
    {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
            InitializeBuffer();

        UpdateBuffer();
        CalculateFPS();
    }

    private void InitializeBuffer()
    {
        if (frameRange <= 0)
            frameRange = 1;

        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);

        if (fpsBufferIndex >= frameRange)
            fpsBufferIndex = 0;
    }

    private void CalculateFPS()
    {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;

        for (int count = 0; count < frameRange; count++)
        {
            int fps = fpsBuffer[count];
            sum += fps;

            if (fps > highest)
                highest = fps;

            if (fps < lowest)
                lowest = fps;
        }

        AverageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }
}