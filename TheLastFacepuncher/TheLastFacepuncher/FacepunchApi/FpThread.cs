using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheLastFacepuncher.FacepunchApi
{
    public class FPThread
    {
        public int ID;
        public string Title;
        public int Replies;
        public int Views;
        public string Author;
        public int AuthorID;
        public int Pages;
        public List<FpPost> Posts;
        public string LastPostTime;

        public void GetThreadPosts()
        {
            this.Posts = new List<FpPost>() { };
            for (int i = 1; i <= Pages; i++)
            {
                foreach (FpPost post in GetPosts(ID, i))
                {
                    Posts.Add(post);
                }
            }
        }

        private List<FpPost> GetPosts(int thread_id, int page)
        {
            PostSubmitter ps = new PostSubmitter();
            List<FpPost> posts = new List<FpPost>() { };
            ps.Type = PostSubmitter.PostTypeEnum.Get;
            ps.Url = "https://api.facepun.ch/";
            ps.PostItems.Add("username", FpAPI.Username);
            ps.PostItems.Add("password", FpAPI.Password);
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