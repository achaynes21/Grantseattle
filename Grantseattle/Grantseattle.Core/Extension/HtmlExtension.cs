using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;

namespace InventoryERP.Core
{
	public static class HtmlExtension
	{
		private static MvcHtmlString preload(string path)
		{
			string html = "<div style='position:absolute;left:-9999px;top:-9999px;width:0;height:0;overflow:hidden;'>";

			List<string> flags = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + path).ToList<string>();

			flags = flags.FindAll(img => img.EndsWith(".db") == false && img.EndsWith(".bak") == false);

			if (flags.Count > 0)
			{
				foreach (string flag in flags)
				{
					html += "<img src='/" + path.Replace("\\", "/") + "/" + Path.GetFileName(flag) + "' alt='' />";
				}
			}
			html += "</div>";

			return new MvcHtmlString(html);
		}

		public static MvcHtmlString Preload(this HtmlHelper htmlHelper, string path)
		{
			return preload(path);
		}

		public static MvcHtmlString PreloadImages(this HtmlHelper htmlHelper)
		{
			return preload("images");
		}

		public static MvcHtmlString PreloadFlags(this HtmlHelper htmlHelper)
		{
			return preload("media/flags");
		}
	}
}
