using LatihanQuiz.Factories;
using LatihanQuiz.Model;
using LatihanQuiz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LatihanQuiz.View
{
    public partial class AddPage : System.Web.UI.Page
    {
        LatihanEntities3 db = new LatihanEntities3();

        protected void Page_Load()
        {
            if (Session["user"] != null && Request.Cookies["user"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == Username.Text && u.Password == Password.Text);

            if (user == null) return;

            LoginOrRegister(user);
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Username = Username.Text,
                Password = Password.Text,
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            LoginOrRegister(newUser);
        }

        protected void LoginOrRegister(User user)
        {
            // Buat Session
            Session["user"] = user;

            // Buat Cookies
            HttpCookie cookie = new HttpCookie("user");
            cookie.Value = user.Username;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            Response.Redirect("HomePage.aspx");
        }
    }
}