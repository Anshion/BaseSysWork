using UnityEngine;
using System.Collections;

public enum Quality
{
	HIGH = 30,
	LOW = 10,
	STANDARD = 20,
	ULTRA = 40
}

public class QualityManager : MonoBehaviour
{
	// Fields
	private static bool[] features = new bool[6];
	public bool forceLowGUIQualityInEditor;
	private static Quality guiQuality = Quality.STANDARD;
	public Quality inEditorQuality = Quality.STANDARD;
	private static bool nvidiaSHIELD = false;
	private static Quality quality = Quality.STANDARD;
	private static bool qualityInitialized;
	public bool useInEditorQuality;
	
	// Methods
	public static Quality GetGUIQuality()
	{
		InitQuality();
		return guiQuality;
	}
	
	public static Quality GetQuality()
	{
		InitQuality();
		return quality;
	}
	
	public static bool HasDecorations()
	{
		InitQuality();
		return features[3];
	}
	
	public static bool HasFog()
	{
		InitQuality();
		return features[0];
	}
	
	public static bool HasHighQualityShading()
	{
		InitQuality();
		return features[2];
	}
	
	public static bool HasRotatePickups()
	{
		InitQuality();
		return features[4];
	}
	
	public static bool HasShadows()
	{
		InitQuality();
		return (features[1] && HasHighQualityShading());
	}
	
	public static bool HasWeatherParticles()
	{
		InitQuality();
		return features[5];
	}
	
	private static void InitFeatures()
	{
		for (int i = 0; i < 6; i++)
		{
			features[i] = false;
		}
		switch (quality)
		{
		case Quality.LOW:
			InitLowQuality();
			break;
			
		case Quality.STANDARD:
			InitStandardQuality();
			break;
			
		case Quality.HIGH:
			InitHighQuality();
			break;
			
		case Quality.ULTRA:
			InitUltraQuality();
			break;
		}
	}
	
	private static void InitHighQuality()
	{
		features[3] = true;
		features[4] = true;
		features[2] = true;
		features[5] = true;
	}
	
	private static void InitLowQuality()
	{
	}
	
	private static void InitQuality()
	{
		if (!qualityInitialized)
		{
			qualityInitialized = true;
			nvidiaSHIELD = SystemInfo.deviceModel.ToLower().Contains("shield");
			if (IsLowQualityDevice())
			{
				quality = Quality.LOW;
			}
			else if (nvidiaSHIELD)
			{
				quality = Quality.ULTRA;
			}
			else if (ConfigParams.Instance == null)
			{
				Debug.LogWarning("Config params not found. Loading low quality");
				quality = Quality.LOW;
			}
			else
			{
				ConfigParams.Quality qualitySettings = ConfigParams.Instance.GetQualitySettings();
				if (qualitySettings != ConfigParams.Quality.Med)
				{
					if (qualitySettings != ConfigParams.Quality.High)
					{
						quality = Quality.LOW;
					}
					else
					{
						quality = Quality.HIGH;
					}
				}
				else
				{
					quality = Quality.STANDARD;
				}
			}
			if (IsLowGUIQualityDevice())
			{
				guiQuality = Quality.LOW;
			}
			else
			{
				guiQuality = Quality.STANDARD;
			}
			InitFeatures();
		}
	}
	
	private static void InitStandardQuality()
	{
		features[0] = true;
		features[3] = true;
		features[4] = true;
		features[2] = true;
	}
	
	private static void InitUltraQuality()
	{
		features[1] = true;
		features[2] = true;
		features[3] = true;
		features[4] = true;
		features[5] = true;
	}
	
	public static bool IsAtLeastQuality(Quality q)
	{
		InitQuality();
		return (quality >= q);
	}
	
	private static bool IsLowGUIQualityDevice()
	{
		return false;
	}
	
	private static bool IsLowQualityDevice()
	{
		return false;
	}
	
	public static bool IsSHIELD()
	{
		return nvidiaSHIELD;
	}
	
	public static void ReloadQuality()
	{
		qualityInitialized = false;
	}
	
	// Nested Types
	private enum Feature
	{
		FOG,
		SHADOWS,
		SURFACE_SHADING,
		DECORATIONS,
		ROTATE_PICKUPS,
		WEATHER_PARTICLES,
		SIZE
	}
}
