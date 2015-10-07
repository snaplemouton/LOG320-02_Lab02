<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LOG320_02_Lab02._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        This application only purpose is to solve Sudokus and ruin the fun of actually doing it yourself. Enjoy!
    </p>
    <hr />
    <h2>Solve a Sudoku using a text file</h2>
    Use a text file using a format of 9 lines with 9 numbers each. 0 for blanks and 1-9 for actual numbers.
    <br />
    <input type="file" id="sudokuTextFile" name="sudokuTextFile" />
    <asp:Button runat="server" ID="btnTextFile" OnClick="solveTextFile" Text="Solve this Sudoku text file" />
    <br />
    Note: Upon clicking this button, the application will solve the Sudoku and return a new text file with the same results found below.
    <hr />
    <h2>Solve a Sudoku using the built-in super high-tech Sudoku builder 101</h2>
    Fill in the blanks to make the base Sudoku to solve and press Solve for the application to fill the other blanks.
    <br />
    <asp:Button runat="server" ID="btnTemplate" OnClick="solveTemplate" Text="Solve this Sudoku template" />
    <br />
    Note: Upon clicking this button, the application will solve the Sudoku and return a new text file with the same results found below.
    <hr />
    <h2>Results</h2>
    Time taken: <asp:Label />
    <br />
    Solved Sudoku
    <br />
</asp:Content>