Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace WindowsApplication133
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim dt As New DataTable()
			For i As Integer = 0 To 49
				Const c As String = "caption"
				Dim sb As New StringBuilder()
				Dim n As Integer = i+1
				Do While n>0
					sb.Append(c.Chars(n Mod c.Length))
					n /= c.Length
				Loop
				dt.Columns.Add(sb.ToString())
				cGridView1.Columns.AddField(sb.ToString()).Visible = False
			Next i
			cGridControl1.DataSource = dt
			cGridView1.ColumnsCustomization()
		End Sub
	End Class
End Namespace