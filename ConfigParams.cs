using UnityEngine;
using System.Collections;
using System;

public class ConfigParams
{
	// Fields
	public bool alreadyRated;
	public int ConsecutiveDays;
	public int daysFromFirstStart;
	public int daysFromLastRateQuestion;
	public int DeathsCount;
	public string decSep = ",";
	public bool fullScreen;
	public float fxVolume = 1f;
	public bool grimmyShowAtLeastOnce;
//	public DateTime installDateTime = DateTime.Now;
	private static FF_ConfigParams instance;
	public string locale = "Global";
	public float masterVolume = 1f;
	public float musicVolume = 1f;
	public bool neverAskForRate;
	public int PlaysCount;
	public Quality QualitySetting;
	public bool rateAsked;
	public int sessionsCount;
	public bool useCloud = true;
	public bool useGameCenter = true;
	public bool useGameMusic = true;
	public bool useIpodMusic;
	public bool useLeaderboardsAndAchievementsBackend = true;
	public bool useZeemote = true;
	public bool zeemoteConnected;
	
	// Methods
	protected ConfigParams()
	{
		this.QualitySetting = (Quality) PlayerPrefsWrapper.GetInt("Quality", (int) this.QualitySetting);
//		int @int = PlayerPrefsWrapper.GetInt("InstallDateInSecs", 0);
//		if (@int != 0)
//		{
//			this.installDateTime = DateUtil.ConvertToDateTime(@int);
//		}
//		else
//		{
//			this.installDateTime = DateTime.Now;
//			PlayerPrefsWrapper.SetInt("InstallDateInSecs", DateUtil.ConvertToInt32(this.installDateTime));
//		}
		this.sessionsCount = PlayerPrefsWrapper.GetInt("TotalSessions", 0) + 1;
		this.PlaysCount = PlayerPrefsWrapper.GetInt("PlaysCount", 0);
		this.DeathsCount = PlayerPrefsWrapper.GetInt("DeathsCount", 0);
		PlayerPrefsWrapper.SetInt("TotalSessions", this.sessionsCount);
		string s = PlayerPrefsWrapper.GetString("FirstStart", string.Empty);
//		DateTime now = DateTime.Now;
//		if (s == string.Empty)
//		{
//			PlayerPrefsWrapper.SetString("FirstStart", DateTime.Now.Date.ToString());
//		}
//		else
//		{
//			now = DateTime.Parse(s);
//			TimeSpan span = (TimeSpan) (DateTime.Now.Date - now);
//			this.daysFromFirstStart = span.Days;
//		}
//		string str2 = PlayerPrefsWrapper.GetString("LastRateQuestion", string.Empty);
//		DateTime minValue = DateTime.MinValue;
//		if (str2 != string.Empty)
//		{
//			minValue = DateTime.Parse(str2);
//			TimeSpan span2 = (TimeSpan) (DateTime.Now.Date - minValue);
//			this.daysFromLastRateQuestion = span2.Days;
//		}
		this.alreadyRated = PlayerPrefsWrapper.GetInt("Rated", 0) == 1;
		this.rateAsked = PlayerPrefsWrapper.GetInt("AskRate", 0) == 1;
		this.neverAskForRate = PlayerPrefsWrapper.GetInt("NeverAskForRate", 0) == 1;
		this.grimmyShowAtLeastOnce = PlayerPrefsWrapper.GetInt("GrimmyShowAtLeastOnce", 0) == 1;
		PlayerPrefsWrapper.Save();
		if (this.PlaysCount == 0)
		{
//			LevelStartPreferences.SetStartTutorialFlag();
		}
	}
	
	public bool CanAskForRate()
	{
		return (!this.neverAskForRate && !this.alreadyRated);
	}
	
	protected Quality GetDefaultSettingsByDevice()
	{
		Quality low = Quality.Low;
		string str = SystemInfo.graphicsDeviceName;
		Debug.LogWarning("graphicsDeviceName:" + str);
		if (str.Contains("Tegra") && str.Contains("3"))
		{
			low = Quality.Med;
		}
		if (str.Contains("Mali") && str.Contains("400"))
		{
			low = Quality.High;
		}
		return low;
	}
	
	public Quality GetQualitySettings()
	{
		return (Quality) PlayerPrefsWrapper.GetInt("Quality", (int) this.GetDefaultSettingsByDevice());
	}
	
	public void IncrementDeathsCount()
	{
		this.DeathsCount++;
		PlayerPrefsWrapper.SetInt("DeathsCount", this.DeathsCount);
		PlayerPrefsWrapper.Save();
	}
	
	public void IncrementPlaysCount()
	{
		this.PlaysCount++;
		PlayerPrefsWrapper.SetInt("PlaysCount", this.PlaysCount);
		PlayerPrefsWrapper.Save();
	}
	
	public static bool IsKongregate()
	{
		if (Application.isEditor)
		{
			return false;
		}
		return ((Application.platform == RuntimePlatform.OSXWebPlayer) || (Application.platform == RuntimePlatform.WindowsWebPlayer));
	}
	
	public virtual void LoadSettings()
	{
		this.musicVolume = PlayerPrefsWrapper.GetFloat("MusicVol", this.musicVolume);
		this.fxVolume = PlayerPrefsWrapper.GetFloat("FXVol", this.fxVolume);
		this.useGameCenter = PlayerPrefsWrapper.GetInt("UseGameCenter", !this.useGameCenter ? 0 : 1) == 1;
		this.useCloud = PlayerPrefsWrapper.GetInt("UseCloud", !this.useCloud ? 0 : 1) == 1;
		this.useIpodMusic = PlayerPrefsWrapper.GetInt("UseIpodMusic", !this.useIpodMusic ? 0 : 1) == 1;
	}
	
	public void NeverAskForRate()
	{
		this.neverAskForRate = true;
		PlayerPrefsWrapper.SetInt("NeverAskForRate", 1);
		PlayerPrefsWrapper.Save();
	}
	
	public void RateGame()
	{
		PlayerPrefsWrapper.SetInt("Rated", 1);
		this.alreadyRated = true;
		PlayerPrefsWrapper.Save();
	}
	
	public void RateQuestionAsked()
	{
		this.daysFromLastRateQuestion = 0;
		PlayerPrefsWrapper.SetString("LastRateQuestion", DateTime.Now.Date.ToString());
		PlayerPrefsWrapper.SetInt("AskRate", 1);
		PlayerPrefsWrapper.Save();
		this.rateAsked = true;
	}
	
	public void ResetProgress()
	{
		this.PlaysCount = 0;
		this.DeathsCount = 0;
		this.grimmyShowAtLeastOnce = false;
		PlayerPrefsWrapper.SetInt("PlaysCount", 0);
		PlayerPrefsWrapper.SetInt("DeathsCount", 0);
		PlayerPrefsWrapper.SetInt("GrimmyShowAtLeastOnce", 0);
		PlayerPrefsWrapper.Save();
	}
	
	public virtual void SaveSettings()
	{
		PlayerPrefsWrapper.SetFloat("MusicVol", this.musicVolume);
		PlayerPrefsWrapper.SetFloat("FXVol", this.fxVolume);
		PlayerPrefsWrapper.SetInt("UseGameCenter", !this.useGameCenter ? 0 : 1);
		PlayerPrefsWrapper.SetInt("UseCloud", !this.useCloud ? 0 : 1);
		PlayerPrefsWrapper.SetInt("UseIpodMusic", !this.useIpodMusic ? 0 : 1);
		PlayerPrefsWrapper.Save();
	}
	
	public void SetGrimmyShowAtLeastOnce()
	{
		this.grimmyShowAtLeastOnce = true;
		PlayerPrefsWrapper.SetInt("GrimmyShowAtLeastOnce", 1);
	}
	
	public void SetQualitySettings(Quality q)
	{
		this.QualitySetting = q;
		PlayerPrefsWrapper.SetInt("Quality", (int) q);
		QualityManager.ReloadQuality();
	}
	
	// Properties
	public static FF_ConfigParams Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new FF_ConfigParams();
			}
			return instance;
		}
	}
	
	// Nested Types
	public enum Quality
	{
		Low,
		Med,
		High
	}
}

