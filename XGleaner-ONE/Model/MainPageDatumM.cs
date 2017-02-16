namespace XGleaner_ONE.Model
{

	public class MainPageDatum
	{
		public int res { get; set; }
		public Datum[] data { get; set; }
	}

	public class Datum
	{
		public string hpcontent_id { get; set; }
		public string hp_title { get; set; }
		public string author_id { get; set; }
		public string hp_img_url { get; set; }
		public string hp_img_original_url { get; set; }
		public string hp_author { get; set; }
		public string ipad_url { get; set; }
		public string hp_content { get; set; }
		public string hp_makettime { get; set; }
		public string hide_flag { get; set; }
		public string last_update_date { get; set; }
		public string web_url { get; set; }
		public string wb_img_url { get; set; }
		public string image_authors { get; set; }
		public string text_authors { get; set; }
		public string image_from { get; set; }
		public string text_from { get; set; }
		public string content_bgcolor { get; set; }
		public string template_category { get; set; }
		public string maketime { get; set; }
		public Share_List share_list { get; set; }
		public int praisenum { get; set; }
		public int sharenum { get; set; }
		public int commentnum { get; set; }

		public string hp_content_noauthor { get; set; }
		public string hp_content_author { get; set; }
		public string hp_title_format { get; set; }
		public string hp_markettime_format { get; set; }
	}

	public class Share_List
	{
		public Wx wx { get; set; }
		public Weibo weibo { get; set; }
		public Qq qq { get; set; }
	}

	public class Wx
	{
		public string title { get; set; }
		public string desc { get; set; }
		public string link { get; set; }
		public string imgUrl { get; set; }
	}

	public class Weibo
	{
		public string title { get; set; }
		public string desc { get; set; }
		public string link { get; set; }
		public string imgUrl { get; set; }
	}

	public class Qq
	{
		public string title { get; set; }
		public string desc { get; set; }
		public string link { get; set; }
		public string imgUrl { get; set; }
	}
}
