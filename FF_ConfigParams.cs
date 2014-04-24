using UnityEngine;
using System.Collections;

public class FF_ConfigParams : ConfigParams
{
	// Fields
	public const bool DEACTIVATE_GORE = false;
	private bool useGore;
	
	// Methods
	public override void LoadSettings()
	{
		base.LoadSettings();
		this.useGore = PlayerPrefsWrapper.GetInt("UseGore", 1) == 1;
	}
	
	public override void SaveSettings()
	{
		base.SaveSettings();
		PlayerPrefsWrapper.SetInt("UseGore", !this.useGore ? 0 : 1);
	}
	
	public void SetGore(bool gore)
	{
		this.useGore = gore;
	}
	
	public bool UseGore()
	{
		return this.useGore;
	}
}



