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
    Under construction
    <!--
    Fill in the blanks to make the base Sudoku to solve and press Solve for the application to fill the other blanks.
    <br />
    <asp:Button runat="server" ID="btnTemplate" OnClick="solveTemplate" Text="Solve this Sudoku template" />
    <br />
    Note: Upon clicking this button, the application will solve the Sudoku and return a new text file with the same results found below.
    -->
    <hr />
    <h2>Results</h2>
    Time taken: <asp:Label />
    <br />
    Solved Sudoku
    <br />
    <div id="solvedSudoku" runat="server"></div>
    <!--<table>
        <tr id="row1">
            <td id="row1node1"></td>
            <td id="row1node2"></td>
            <td id="row1node3"></td>
            <td id="row1node4"></td>
            <td id="row1node5"></td>
            <td id="row1node6"></td>
            <td id="row1node7"></td>
            <td id="row1node8"></td>
            <td id="row1node9"></td>
        </tr>
        <tr id="row2">
            <td id="row2node1"></td>
            <td id="row2node2"></td>
            <td id="row2node3"></td>
            <td id="row2node4"></td>
            <td id="row2node5"></td>
            <td id="row2node6"></td>
            <td id="row2node7"></td>
            <td id="row2node8"></td>
            <td id="row2node9"></td>
        </tr>
        <tr id="row3">
            <td id="row3node1"></td>
            <td id="row3node2"></td>
            <td id="row3node3"></td>
            <td id="row3node4"></td>
            <td id="row3node5"></td>
            <td id="row3node6"></td>
            <td id="row3node7"></td>
            <td id="row3node8"></td>
            <td id="row3node9"></td>
        </tr>
        <tr id="row4">
            <td id="row4node1"></td>
            <td id="row4node2"></td>
            <td id="row4node3"></td>
            <td id="row4node4"></td>
            <td id="row4node5"></td>
            <td id="row4node6"></td>
            <td id="row4node7"></td>
            <td id="row4node8"></td>
            <td id="row4node9"></td>
        </tr>
        <tr id="row5">
            <td id="row5node1"></td>
            <td id="row5node2"></td>
            <td id="row5node3"></td>
            <td id="row5node4"></td>
            <td id="row5node5"></td>
            <td id="row5node6"></td>
            <td id="row5node7"></td>
            <td id="row5node8"></td>
            <td id="row5node9"></td>
        </tr>
        <tr id="row6">
            <td id="row6node1"></td>
            <td id="row6node2"></td>
            <td id="row6node3"></td>
            <td id="row6node4"></td>
            <td id="row6node5"></td>
            <td id="row6node6"></td>
            <td id="row6node7"></td>
            <td id="row6node8"></td>
            <td id="row6node9"></td>
        </tr>
        <tr id="row7">
            <td id="row7node1"></td>
            <td id="row7node2"></td>
            <td id="row7node3"></td>
            <td id="row7node4"></td>
            <td id="row7node5"></td>
            <td id="row7node6"></td>
            <td id="row7node7"></td>
            <td id="row7node8"></td>
            <td id="row7node9"></td>
        </tr>
        <tr id="row8">
            <td id="row8node1"></td>
            <td id="row8node2"></td>
            <td id="row8node3"></td>
            <td id="row8node4"></td>
            <td id="row8node5"></td>
            <td id="row8node6"></td>
            <td id="row8node7"></td>
            <td id="row8node8"></td>
            <td id="row8node9"></td>
        </tr>
        <tr id="row9">
            <td id="row9node1"></td>
            <td id="row9node2"></td>
            <td id="row9node3"></td>
            <td id="row9node4"></td>
            <td id="row9node5"></td>
            <td id="row9node6"></td>
            <td id="row9node7"></td>
            <td id="row9node8"></td>
            <td id="row9node9"></td>
        </tr>
    </table>-->
</asp:Content>