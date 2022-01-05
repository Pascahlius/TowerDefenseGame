using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankLevel
{
    public int cost;
    public GameObject display;
}

public class TankData : MonoBehaviour
{
    public List<TankLevel> level;
    [SerializeField] TankLevel currentLevel;

    private void OnEnable()
    {
        currentLevel = level[0];
        SetTankLevel(currentLevel);
    }

    public TankLevel GetTankLevel()
    {
        return currentLevel;
    }

    public void SetTankLevel(TankLevel tankLevel)
    {
        currentLevel = tankLevel;

        int currentLevelIndex = level.IndexOf(currentLevel);

        GameObject levelDisplay = level[currentLevelIndex].display;

        for (int i = 0; i<level.Count; i++)
        {
            if (levelDisplay != null)
            {
                if (i == currentLevelIndex)
                {
                    level[i].display.SetActive(true);
                }else
                {
                    level[i].display.SetActive(false);
                }
            }
        }
    }

    public void IncreaseLevel()
    {
        int currentLevelIndex = level.IndexOf(currentLevel);
        if (currentLevelIndex < level.Count - 1)
        {
            currentLevel = level[currentLevelIndex + 1];
            SetTankLevel(currentLevel);
        }
    }
    
    public TankLevel GetNextLevel()
    {
        int currentLevelIndex = level.IndexOf(currentLevel);
        int maxLevelIndex = level.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return level[currentLevelIndex + 1];
        } else
        {
            return null;
        }
    }
}
