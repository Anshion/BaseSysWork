using UnityEngine;

public class PlayerPrefsWrapper
{
	// Methods
	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}
	
	public static void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}
	
	public static byte[] GetByteArray(string key, byte[] defValue)
	{
		string encodedData = PlayerPrefs.GetString(key, string.Empty);
		if (encodedData == string.Empty)
		{
			return defValue;
		}
		return defValue;
//		return StringUtil.DecodeFrom64ToByteArray(encodedData);
	}
	
	public static float GetFloat(string key, float defValue)
	{
		return PlayerPrefs.GetFloat(key, defValue);
	}
	
	public static int GetInt(string key, int defValue)
	{
		return PlayerPrefs.GetInt(key, defValue);
	}
	
	public static string GetString(string key, string defValue)
	{
		return PlayerPrefs.GetString(key, defValue);
	}
	
	public static bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}
	
	public static void Save()
	{
		PlayerPrefs.Save();
	}
	
	public static void SetByteArray(string key, byte[] val)
	{
//		PlayerPrefs.SetString(key, StringUtil.EncodeTo64(val));
	}
	
	public static void SetFloat(string key, float val)
	{
		PlayerPrefs.SetFloat(key, val);
	}
	
	public static void SetInt(string key, int val)
	{
		PlayerPrefs.SetInt(key, val);
	}
	
	public static void SetString(string key, string val)
	{
		PlayerPrefs.SetString(key, val);
	}
}



