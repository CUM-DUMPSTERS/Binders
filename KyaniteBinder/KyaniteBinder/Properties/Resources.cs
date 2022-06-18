using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace KyaniteBinder.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		internal Resources()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("KyaniteBinder.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static string ExtraCode
		{
			get
			{
				return Resources.ResourceManager.GetString("ExtraCode", Resources.resourceCulture);
			}
		}
		
		internal static string MainCode
		{
			get
			{
				return Resources.ResourceManager.GetString("MainCode", Resources.resourceCulture);
			}
		}

		internal static byte[] ResHacker
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("ResHacker", Resources.resourceCulture);
			}
		}
		
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
	}
}
