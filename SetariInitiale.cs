using System.Configuration;
using System.Diagnostics;

namespace Scanare_Angajati
{
	internal sealed class SetariInitiale : ApplicationSettingsBase
	{
		private static SetariInitiale defaultInstance = (SetariInitiale)SettingsBase.Synchronized(new SetariInitiale());
		public static SetariInitiale Default
		{
			get
			{
				return SetariInitiale.defaultInstance;
			}
		}
		[DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
		public string serverIP
		{
			get
			{
				return (string)this["serverIP"];
			}
			set
			{
				this["serverIP"] = value;
			}
		}
		[DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
		public string databaseName
		{
			get
			{
				return (string)this["databaseName"];
			}
			set
			{
				this["databaseName"] = value;
			}
		}
		[DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
		public string portNo
		{
			get
			{
				return (string)this["portNo"];
			}
			set
			{
				this["portNo"] = value;
			}
		}
		[DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
		public string dUsername
		{
			get
			{
				return (string)this["dUsername"];
			}
			set
			{
				this["dUsername"] = value;
			}
		}
		[DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
		public string dPassword
		{
			get
			{
				return (string)this["dPassword"];
			}
			set
			{
				this["dPassword"] = value;
			}
		}
	}
}
