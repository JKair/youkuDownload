using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youkudownload
{
    class ProcessUrl
    {
        string downloadUrl;         //用户输入的下载链接
        string openApi = "http://v.youku.com/player/getPlayList/VideoIDS/";     //优酷的api
        string sid;         
        public string downloadYouKuUrl;     //处理完毕的优酷链接
        public string title;                //下载视频的名字
        public string media_flage;          //格式

        public ProcessUrl(string downloadUrl)
        {
            this.downloadUrl = downloadUrl;
        }

        /// <summary>
        /// 用来处理链接的函数
        /// </summary>
        /// <returns>成功返回ture,否则返回false</returns>
        public bool parse()
        {
            string vidioId = findId();
            string fileId="";
            if (vidioId == "")
            {
                MessageBox.Show("输入链接错误！");
                return false;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(openApi+vidioId);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream recStream = response.GetResponseStream();

            Encoding utf8 = Encoding.GetEncoding("utf-8");

            StreamReader sr = new StreamReader(recStream, utf8);

            String content = sr.ReadToEnd();

            JObject openJson = (JObject)JsonConvert.DeserializeObject(content);         //处理优酷返回的json
            string flv = (string)openJson["data"][0]["streamfileids"]["flv"];
            string mp4 = (string)openJson["data"][0]["streamfileids"]["mp4"];

            JToken media_blocks=null;
            if (mp4 != null)
            {
                fileId = mp4;
                media_blocks = openJson["data"][0]["segs"]["mp4"];
                media_flage = "mp4";
            }
            else
            {
                if (flv != null)
                {
                    media_blocks = openJson["data"][0]["segs"]["flv"];
                    fileId = flv;
                    media_flage = "flv";
                }
            }
            title = (string)openJson["data"][0]["title"];
            string ct = (string)openJson["data"][0]["ct"];
            string cs = (string)openJson["data"][0]["cs"];
            string key1 = (string)openJson["data"][0]["key1"];
            string key2 = (string)openJson["data"][0]["key2"];
            string seed = (string)openJson["data"][0]["seed"];
            string userid = (string)openJson["data"][0]["userid"];
            string videoid = (string)openJson["data"][0]["videoid"];
            string totalsec = (string)openJson["data"][0]["seconds"];

            getSid();
            string fid=getFid(fileId, seed);
            string blocks_key = getKey(media_blocks);

            string youkuFileUrl = "http://f.youku.com/player/getFlvPath/sid/";

            string hexCurrentBlock = "00";

            string newS = fid.Substring(0, 8);
            newS = newS + hexCurrentBlock + fid.Substring(10, fid.Length-10);


            downloadYouKuUrl = youkuFileUrl + sid + "_" + hexCurrentBlock + "/st/" + media_flage + "/fileid/" + newS + "?K=" + blocks_key;
            return true;
        }

        /// <summary>
        /// 得到优酷的关键key
        /// </summary>
        /// <param name="media_blocks">json字段</param>
        /// <returns>关键key</returns>
        private string getKey(JToken media_blocks)      
        {
            return (string)media_blocks[0]["k"];
        }

        /// <summary>
        /// 利用某算法算出sid
        /// </summary>
        private void getSid()           
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000000; 
            Random rad = new Random();
            sid = t.ToString() + (rad.Next(0, 9000) + 10000).ToString();
        }

        /// <summary>
        /// 处理文件的id
        /// </summary>
        /// <param name="fileid">未经处理的id</param>
        /// <param name="seed">Json中的seed</param>
        /// <returns>处理完毕的id</returns>
        private string getFid(string fileid,string seed)        
        {
            string mixed = getMixString(seed);
            string[] ids = fileid.Split('*');
            string readId = "";
            int i=0;
            while (i<ids.Length-1)
            {
                int idx = Int32.Parse(ids[i]);
                readId += mixed.Substring(idx,1);
                i++;
            }
            return readId;
        }

        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="seed">Json中的seed</param>
        /// <returns>完成算法得到的混合字符串</returns>
        private string getMixString(string seed)
        {
            string mixed="";
            double seeds = double.Parse(seed);
            int index;
            string source = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/\\:._-1234567890";
            ArrayList sources = new ArrayList();
            foreach (char c in source)
            {
                string result = c.ToString();
                sources.Add(result);
            }

            while (sources.Count != 0)
            {
                seeds = (seeds * 211 + 30031) % 65536;
                double mid = (seeds / 65536.0);
                index =  (int)(mid * sources.Count);
                string c = (string)sources[index];
                sources.RemoveAt(index);
                mixed += c;
            }
            return mixed;
        }

        /// <summary>
        /// 获得文件的id，用于获取json
        /// </summary>
        /// <returns>文件的id</returns>
        private string findId()     
        {
            string reg = "http://v.youku.com/v_show/id_(?<value>.*?).html";
            MatchCollection mc = Regex.Matches(downloadUrl, reg, RegexOptions.Multiline | RegexOptions.Singleline);
            Match m = mc[0];
            if (m.Success)
            {
                return m.Groups["value"].Value;
            }
            else
            {
                return "";
            }
            return "";
        }
    }
}
