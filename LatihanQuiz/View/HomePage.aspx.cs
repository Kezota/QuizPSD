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
    public partial class WebForm1 : System.Web.UI.Page
    {
        LatihanEntities3 db = new LatihanEntities3();
        FoodFactory factory = new FoodFactory();
        FoodRepository repository = new FoodRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Description.Text) || string.IsNullOrEmpty(Price.Text) || string.IsNullOrEmpty(FoodTypeID.Text))
            {
                ErrorMessage.Text = "Please fill all the inputs";
                return;
            }

            ErrorMessage.Text = "";
            Food newFood = factory.CreateNewFood(Name.Text, Description.Text, int.Parse(Price.Text), int.Parse(FoodTypeID.Text));

            repository.AddFood(newFood);
            BindGrid();
        }

        protected void BindGrid()
        {
            List<Food> foods = repository.GetFoods();

            GridView1.DataSource = foods;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex < 0 || rowIndex >= GridView1.Rows.Count) { return; }

            string foodIdStr = GridView1.Rows[rowIndex].Cells[0].Text;
            int foodId = int.Parse(foodIdStr);

            repository.DeleteFoodById(foodId);

            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            string newId = ((TextBox)GridView1.Rows[rowIndex].Cells[0].Controls[0]).Text;
            string newName = ((TextBox)GridView1.Rows[rowIndex].Cells[1].Controls[0]).Text;
            string newDescription = ((TextBox)GridView1.Rows[rowIndex].Cells[2].Controls[0]).Text;
            string newPrice = ((TextBox)GridView1.Rows[rowIndex].Cells[3].Controls[0]).Text;
            string newFoodTypeId = ((TextBox)GridView1.Rows[rowIndex].Cells[4].Controls[0]).Text;

            Food updatedFood = new Food
            {
                Id = int.Parse(newId),
                Name = newName,
                Description = newDescription,
                Price = int.Parse(newPrice),
                FoodTypeID = int.Parse(newFoodTypeId),
            };

            repository.UpdateFood(updatedFood);

            GridView1.EditIndex = -1;

            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            BindGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Cookies.Clear();
            Response.Redirect("LoginRegisterPage.aspx");
        }
    }
}
