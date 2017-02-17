using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XGleaner_ONE.Model;

namespace XGleaner_ONE.ViewModel.WebService
{
	public class GetMainPageDatumWS
	{
		private async static Task<MainPageDatum> BeginGetMainPageDatumAsync()
		{
			string url = "http://v3.wufazhuce.com:8000/api/hp/more/0?version=v3.5.3";

			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync( url );

			var result = await response.Content.ReadAsStringAsync();

			var ms = new MemoryStream( Encoding.UTF8.GetBytes( result ) );

			var serializer = new DataContractJsonSerializer( typeof( MainPageDatum ) );

			var serializerResult = ( MainPageDatum ) serializer.ReadObject( ms );

			return serializerResult;
		}

		public async static Task FormatMainPageDatumAsync(ObservableCollection<Datum> fMPDC)
		{
			var getMainPageDatum = await BeginGetMainPageDatumAsync();

			var mainPageDatum = getMainPageDatum.data;

			foreach (var datum in mainPageDatum)
			{
				string regexStr = Regex.Replace( datum.hp_title, @"[^\d]", "" );
				datum.hp_title_format = string.Format( "第 " + regexStr + " 期" );

				DateTime dt = DateTime.Parse( datum.hp_makettime );
				string formatDateAndTime = dt.ToString( "yyyy" + " 年 " + "MM" + " 月 " + "dd" + " 日 " );
				datum.hp_markettime_format = string.Format( formatDateAndTime );

				if (datum.hp_content.ToString().Contains( "by" ))
				{
					string onlyContentStr = datum.hp_content;
					onlyContentStr = onlyContentStr.Substring( 0, onlyContentStr.IndexOf( "b" ) + 1 );
					onlyContentStr = onlyContentStr.Replace( "b", "" );
					onlyContentStr = onlyContentStr.Replace( "。", "。"+ Environment.NewLine );
					onlyContentStr = onlyContentStr.Replace( "？", "？" + Environment.NewLine );
					onlyContentStr = onlyContentStr.Replace( "......", "......" + Environment.NewLine );
					datum.hp_content_noauthor = onlyContentStr;

					string onlyAuthorStr = datum.hp_content;
					onlyAuthorStr = onlyAuthorStr.Substring( onlyAuthorStr.IndexOf( 'b' ) + 1 );
					datum.hp_content_author = string.Format( "b" + onlyAuthorStr );
				}
				else if (datum.hp_content.ToString().Contains( "from" ))
				{
					string onlyContentStr = datum.hp_content;
					onlyContentStr = onlyContentStr.Substring( 0, onlyContentStr.IndexOf( "f" ) + 1 );
					onlyContentStr = onlyContentStr.Replace( "f", "" );
					onlyContentStr = onlyContentStr.Replace( "。", "。" + Environment.NewLine );
					onlyContentStr = onlyContentStr.Replace( "？", "？" + Environment.NewLine );
					onlyContentStr = onlyContentStr.Replace( "……", "……" + Environment.NewLine );
					datum.hp_content_noauthor = onlyContentStr;

					string onlyAuthorStr = datum.hp_content;
					onlyAuthorStr = onlyAuthorStr.Substring( onlyAuthorStr.IndexOf( "f" ) + 1 );
					datum.hp_content_author = string.Format( "f" + onlyAuthorStr );
				}
				else
				{
					datum.hp_content_noauthor = datum.hp_content;
					datum.hp_content_author = "";
				}

				fMPDC.Add( datum );
			}
		}
	}
}
