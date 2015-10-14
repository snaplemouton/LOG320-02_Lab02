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
    Use a text file using a format of 9 lines with 9 numbers each. 0 for blanks and 1-9 for numbers.
    <br />
    <input type="file" id="sudokuTextFile" name="sudokuTextFile" />
    <asp:Button runat="server" ID="btnOpenSudoku" OnClick="openSudoku" Text="Load Sudoku" />
    <asp:Button runat="server" ID="btnSolveSudoku" OnClick="solveSudoku" Text="Solve Sudoku" />
    <hr />
    Time taken to solve: <div id="timeTaken" runat="server"></div>
    <br />
    Sudoku
    <br />
    <div id="solvedSudoku" runat="server"></div>
</asp:Content>