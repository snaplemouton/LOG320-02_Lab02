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
                    int y = 0;
                    int x = 0;
                    string style = "";
                    string tablestring = "<table style='width:300px;height:300px;text-align:center;border-collapse:collapse'>";
                    foreach (SudokuNodeArray sna in sudoku.Rows)
                    {
                        tablestring += "<tr>";
                        foreach (SudokuNode sn in sna.Nodes)
                        {
                            if (y == 0 || y == 3 || y == 6) style += "border-top:2px solid black;";
                            if (y == 2 || y == 5 || y == 8) style += "border-bottom:2px solid black;";
                            if (x == 0 || x == 3 || x == 6) style += "border-left:2px solid black;";
                            if (x == 2 || x == 5 || x == 8) style += "border-right:2px solid black;";
                            tablestring += "<td style='border:1px solid black;" + style + "'>" + sn.Value.ToString() + "</td>";
                            style = "";
                            x++;
                        }
                        tablestring += "</tr>";
                        y++;
                        x = 0;
                    }
                    tablestring += "</table>";
 
                    solvedSudoku.InnerHtml = tablestring;
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
