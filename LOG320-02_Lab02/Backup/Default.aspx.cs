using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LOG320_02_Lab02.Classes;

namespace LOG320_02_Lab02
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void solveTextFile(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["sudokuTextFile"];
            if (file != null && file.ContentLength > 0)
            {
                SudokuSolver sudokuSolver = new SudokuSolver();
                Sudoku sudoku = sudokuSolver.SolveTextFile(file);

                if (sudoku != null)
                {

                }
                else
                {
                    popupAlert("Fichier invalide.");
                }
            }
            else
            {
                popupAlert("Veuillez choisir un fichier valide.");
            }

        }

        protected void solveTemplate(object sender, EventArgs e)
        {

        }

        private void popupAlert(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}
