using HyperTemplate;
using UnityEngine;

public class SampleLevel :Level
{
    public Transform startPos;
    public Transform finishCamPos;

    protected override void WhenLevelLoad()
    {
        currentLevelData.mainCam.SetToDefaultPos();
        hyperCentralObjects.Add(currentLevelData.samplePlayer);
        currentLevelData.samplePlayer.transform.position = startPos.position;
        currentLevelData.mainCam.Initialize(currentLevelData.samplePlayer.transform);
        currentLevelData.samplePlayer.ReadyForStart();
    }

    public override void StartLevel()
    {
        currentLevelData.samplePlayer.StartLevel();
    }

    public override void EndLevel(bool isWin)
    {
        if (isWin)
        {
            // currentLevelData.mainCam.FinishPosition(finishCamPos.transform.position,
            //     currentLevelData.samplePlayer.transform.position);
        }

        else
        {
            // Vector3 destPos = currentLevelData.samplePlayer.transform.position + new Vector3(0, 8, 13);
            // currentLevelData.mainCam.FinishPosition(destPos,
            //     currentLevelData.samplePlayer.transform.position);
            currentLevelData.mainCam.StopCamera();
        }

        currentLevelData.samplePlayer.EndLevel(true);
    }
}