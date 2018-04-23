Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid.Customization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Customization

Namespace CGrid
	Public Class CGridControl
		Inherits GridControl
		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New CGridViewInfoRegistrator())
		End Sub
		Protected Overrides Function CreateDefaultView() As BaseView
			Return CreateView("CGridView")
		End Function
	End Class

	Public Class CGridView
		Inherits GridView
		Public Sub New()
			Me.New(Nothing)
		End Sub

		Public Sub New(ByVal gc As GridControl)
			MyBase.New(gc)
		End Sub

		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "CGridView"
			End Get
		End Property

		Protected Overrides Function CreateCustomizationForm() As CustomizationForm
			Return New MyCustomizationForm(Me)
		End Function
	End Class

	Public Class CGridViewInfoRegistrator
		Inherits GridInfoRegistrator
		Public Overrides ReadOnly Property ViewName() As String
			Get
				Return "CGridView"
			End Get
		End Property
		Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
			Return New CGridView(TryCast(grid, GridControl))
		End Function
	End Class

	Public Class MyCustomizationForm
		Inherits CustomizationForm
		Public Sub New(ByVal view As GridView)
			MyBase.New(view)
		End Sub

		Private _pattern As String
		Public Property Pattern() As String
			Get
				Return _pattern
			End Get
			Set(ByVal value As String)
				_pattern = value
				Me.ActiveListBox.Populate()
			End Set
		End Property

		Private fPatternEdit As TextEdit

		Protected Overrides Sub CreateListBox()
			MyBase.CreateListBox()
			ActiveListBox.Dock = DockStyle.Fill
			ActiveListBox.Populate()
			Controls.Add(ActiveListBox)
			fPatternEdit = New TextEdit()
			fPatternEdit.Dock = DockStyle.Top
			Controls.Add(fPatternEdit)
			fPatternEdit.DataBindings.Add("EditValue", Me, "Pattern", True, DataSourceUpdateMode.OnPropertyChanged)

		End Sub



		Protected Overrides Function CreateCustomizationListBox() As CustomizationListBoxBase
			Dim fActiveListBox As New MyColumnCustomizationListBox(Me)
			Return fActiveListBox
		End Function
	End Class

	Public Class MyColumnCustomizationListBox
		Inherits ColumnCustomizationListBox
		Public Sub New(ByVal form As CustomizationForm)
			MyBase.New(form)
		End Sub
		Public Overrides Sub Populate()
			Dim pattern As String = (TryCast(Me.CustomizationForm, MyCustomizationForm)).Pattern
			MyBase.Items.BeginUpdate()
			Try
				MyBase.Items.Clear()
				Dim list As New ArrayList()
				For Each column As GridColumn In MyBase.View.Columns
					If column.CanShowInCustomizationForm Then
						If String.IsNullOrEmpty(pattern) OrElse GetCustomizationCaption(column).StartsWith(pattern) Then
							list.Add(column)
						End If
					End If
				Next column
				list.Sort(New ColumnComparer())
				For Each column As GridColumn In list
					MyBase.Items.Add(column)
				Next column
			Finally
				MyBase.Items.EndUpdate()
			End Try

		End Sub

		Private Shared Function GetCustomizationCaption(ByVal col As GridColumn) As String
			Dim s As String = col.CustomizationCaption
			If String.IsNullOrEmpty(s) Then
				s = col.Caption
			End If
			If String.IsNullOrEmpty(s) Then
				s = col.FieldName
			End If
			Return s
		End Function

		Private Class ColumnComparer
			Implements IComparer
			Private Function IComparer_Compare(ByVal a As Object, ByVal b As Object) As Integer Implements IComparer.Compare
				Dim c1 As GridColumn = CType(a, GridColumn)
				Dim c2 As GridColumn = CType(b, GridColumn)
				Dim res As Integer = Comparer.Default.Compare(GetCustomizationCaption(c1), GetCustomizationCaption(c2))
				If res = 0 Then
					res = Comparer.Default.Compare(c1.AbsoluteIndex, c2.AbsoluteIndex)
				End If
				Return res
			End Function
		End Class
	End Class
End Namespace