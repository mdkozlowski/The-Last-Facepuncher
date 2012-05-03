using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheLastFacepuncher.FacepunchApi
{
    public class FpAPI
    {
        public static string Username;
        public static string Password;

        public FpAPI(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public FpAPI()
        {
            Username = "";
            Password = "";
        }

        public static string ConvertToMD5(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public List<FPThread> GetThreads(int forum_id)
        {
            PostSubmitter ps = new PostSubmitter("http://api.facepun.ch/");
            ps.Type = PostSubmitter.PostTypeEnum.Get;
            ps.Url = "http://api.facepun.ch/";
            List<FPThread> threads = new List<FPThread>() { };
            ps.PostItems.Add("username", Username);
            ps.PostItems.Add("password", Password);
            ps.PostItems.Add("action", "getthreads");
            ps.PostItems.Add("forum_id", forum_id.ToString());
            //ps.PostItems.Add("forum_id", "240");
            string response = ps.Post();
            JObject objeect = JObject.Parse(response);
            JArray events = (JArray)objeect["threads"];
            foreach (JToken ev in events)
            {
                string title = ev["title"].ToString();
                int replies = int.Parse(ev["replies"].ToString());
                int views = int.Parse(ev["views"].ToString());
                int id = int.Parse(ev["id"].ToString());
                int authorID = int.Parse(ev["authorid"].ToString());
                string author = ev["author"].ToString();
                int pages = int.Parse(ev["pages"].ToString());
                string lastposttime = ev["lastposttime"].ToString();
                FPThread thread = new FPThread();
                thread.Title = title;
                thread.Replies = replies;
                thread.Views = views;
                thread.ID = id;
                thread.Author = author;
                thread.AuthorID = authorID;
                thread.Pages = pages;
                thread.LastPostTime = lastposttime;
                threads.Add(thread);
            }
            return threads;
        }

        public List<FPThread> GetUnreadThreads()
        {
            PostSubmitter ps = new PostSubmitter("http://api.facepun.ch/");
            ps.Type = PostSubmitter.PostTypeEnum.Get;
            ps.Url = "http://api.facepun.ch/";
            List<FPThread> threads = new List<FPThread>() { };
            ps.PostItems.Add("username", Username);
            ps.PostItems.Add("password", Password);
            ps.PostItems.Add("action", "getreadthreads");
            string response = ps.Post();
            JObject objeect = JObject.Parse(response);
            JArray events = (JArray)objeect["threads"];
            foreach (JToken ev in events)
            {
                string title = ev["title"].ToString();
                int replies = int.Parse(ev["replies"].ToString());
                int views = int.Parse(ev["views"].ToString());
                int id = int.Parse(ev["id"].ToString());
                int authorID = int.Parse(ev["authorid"].ToString());
                string author = ev["author"].ToString();
                int pages = int.Parse(ev["pages"].ToString());
                string lastposttime = ev["lastposttime"].ToString();
                FPThread thread = new FPThread();
                thread.Title = title;
                thread.Replies = replies;
                thread.Views = views;
                thread.ID = id;
                thread.Author = author;
                thread.AuthorID = authorID;
                thread.Pages = pages;
                thread.LastPostTime = lastposttime;
                threads.Add(thread);
            }
            return threads;
        }

        public void Login()
        {
            PostSubmitter ps = new PostSubmitter("http://api.facepun.ch/");
            ps.Type = PostSubmitter.PostTypeEnum.Get;
            ps.Url = "http://api.facepun.ch/";
            ps.PostItems.Add("username", Username);
            ps.PostItems.Add("password", Password);
            ps.PostItems.Add("action", "authenticate");
            ps.Post();
        }

        public List<FpPost> GetPosts(int thread_id)
        {
            PostSubmitter ps = new PostSubmitter("http://api.facepun.ch/");
            ps.Type = PostSubmitter.PostTypeEnum.Get;
            ps.Url = "http://api.facepun.ch/";
            List<FpPost> posts = new List<FpPost>() { };
            ps.PostItems.Add("username", Username);
            ps.PostItems.Add("password", Password);
            ps.PostItems.Add("action", "getposts");
            ps.PostItems.Add("thread_id", thread_id.ToString());
            //ps.PostItems.Add("forum_id", "240");
            string response = ps.Post();
            JObject objeect = JObject.Parse(response);
            JArray events = (JArray)objeect["posts"];
            foreach (JToken ev in events)
            {
                int id = int.Parse(ev["id"].ToString());
                int userid = int.Parse(ev["userid"].ToString());
                string username = ev["username"].ToString();
                string message = ev["message"].ToString();
                //string avatar = ev["avatar"].ToString();

                FpPost post = new FpPost();
                //post.AvatarURL = avatar;
                post.UserID = userid;
                post.UserName = username;
                post.ID = id;
                post.Message = message;
                posts.Add(post);
            }
            return posts;
        }

        public List<FpPost> GetPosts(int thread_id, int page)
        {
            PostSubmitter ps = new PostSubmitter("http://api.facepun.ch/");
            ps.Type = PostSubmitter.PostTypeEnum.Get;
            ps.Url = "http://api.facepun.ch/";
            List<FpPost> posts = new List<FpPost>() { };
            ps.PostItems.Add("username", Username);
            ps.PostItems.Add("password", Password);
            ps.PostItems.Add("action", "getposts");
            ps.PostItems.Add("thread_id", thread_id.ToString());
            ps.PostItems.Add("page", page.ToString());
            //ps.PostItems.Add("forum_id", "240");
            string response = ps.Post();
            JObject objeect = JObject.Parse(response);
            JArray events = (JArray)objeect["posts"];
            foreach (JToken ev in events)
            {
                int id = int.Parse(ev["id"].ToString());
                int userid = int.Parse(ev["userid"].ToString());
                string username = ev["username"].ToString();
                string message = ev["message"].ToString();
                //string avatar = ev["avatar"].ToString();

                FpPost post = new FpPost();
                //post.AvatarURL = avatar;
                post.UserID = userid;
                post.UserName = username;
                post.ID = id;
                post.Message = message;
                posts.Add(post);
            }
            return posts;
        }
    }
}