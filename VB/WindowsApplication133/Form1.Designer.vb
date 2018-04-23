Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication133
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.cGridControl1 = New CGrid.CGridControl()
			Me.cGridView1 = New CGrid.CGridView()
			Me.cGridView2 = New CGrid.CGridView()
			CType(Me.cGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' cGridControl1
			' 
			Me.cGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.cGridControl1.EmbeddedNavigator.Name = ""
			Me.cGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.cGridControl1.MainView = Me.cGridView1
			Me.cGridControl1.Name = "cGridControl1"
			Me.cGridControl1.Size = New System.Drawing.Size(292, 266)
			Me.cGridControl1.TabIndex = 0
			Me.cGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.cGridView1, Me.cGridView2})
			' 
			' cGridView1
			' 
			Me.cGridView1.GridControl = Me.cGridControl1
			Me.cGridView1.Name = "cGridView1"
			' 
			' cGridView2
			' 
			Me.cGridView2.GridControl = Me.cGridControl1
			Me.cGridView2.Name = "cGridView2"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(292, 266)
			Me.Controls.Add(Me.cGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.cGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cGridView2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private cGridControl1 As CGrid.CGridControl
		Private cGridView1 As CGrid.CGridView
		Private cGridView2 As CGrid.CGridView

	End Class
End Namespace

